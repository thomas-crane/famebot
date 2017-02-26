using Lib_K_Relay.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_K_Relay;
using System.Diagnostics;
using FameBot.Data.Enums;
using FameBot.Data.Models;
using Lib_K_Relay.Networking;
using System.Runtime.InteropServices;
using FameBot.Helpers;
using Lib_K_Relay.Networking.Packets;
using Lib_K_Relay.Networking.Packets.Server;
using Lib_K_Relay.Networking.Packets.DataObjects;
using Lib_K_Relay.Utilities;
using Lib_K_Relay.Networking.Packets.Client;
using FameBot.Services;
using FameBot.UserInterface;
using FameBot.Data.Events;

namespace FameBot.Core
{
    public class Plugin : IPlugin
    {
        #region IPlugin
        public string GetAuthor()
        {
            return "Chicken";
        }

        public string[] GetCommands()
        {
            return new string[]
            {
                "TODO: list commands"
            };
        }

        public string GetDescription()
        {
            return "TODO: add description";
        }

        public string GetName()
        {
            return "FameBot by Chicken";
        }
        #endregion

        private IntPtr flashPtr;
        private bool followTarget;
        private List<Target> targets;
        private Dictionary<int, Target> playerPosisions;
        private Client connectedClient;
        private int tickCount;

        private float autoNexusThreshold = 0.45f;
        private int tickCountThreshold = 10;
        private bool escapeIfNoTargets = true;
        private float teleportDistanceThreshold = 15f;
        private float followDistanceThreshold = 1.5f;

        public static event HealthEventHandler healthChanged;
        public delegate void HealthEventHandler(object sender, HealthChangedEventArgs args);

        #region WINAPI
        // Get the focused window
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();
        // Send a message to a specific process via the handle
        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
        #endregion

        #region KeyCodes
        private bool W_PRESSED, A_PRESSED, S_PRESSED, D_PRESSED;
        #endregion

        public void Initialize(Proxy proxy)
        {
            targets = new List<Target>();
            playerPosisions = new Dictionary<int, Target>();

            var gui = new FameBotGUI(GuiEventCallback);
            PluginUtils.ShowGUI(gui);

            Process[] processes = Process.GetProcessesByName("flash");
            if (processes.Length == 1)
            {
                Console.WriteLine("[FameBot] Flash process handle aquired automatically.");
                flashPtr = processes[0].MainWindowHandle;
            } else if(processes.Length > 1)
            {
                Console.WriteLine("[FameBot] Multiple instances of flash are open. Please use the /activate command on the instance you want to use the bot with.");
            } else
            {
                Console.WriteLine("[FameBot] Couldn't find any instances of flash player. Use the /activate command when you have opened flash.");
                Console.WriteLine("[FameBot] FameBot will only detect instances of flash player which are called \"flash.exe\"");
            }

            proxy.HookCommand("activate", ReceiveCommand);
            proxy.HookCommand("start", ReceiveCommand);

            proxy.HookPacket(PacketType.UPDATE, OnUpdate);
            proxy.HookPacket(PacketType.NEWTICK, OnNewTick);

            proxy.ClientConnected += (client) =>
            {
                connectedClient = client;
                Stop();
            };
        }

        private void ReceiveCommand(Client client, string cmd, string[] args)
        {
            switch(cmd)
            {
                case "activate":
                    flashPtr = GetForegroundWindow();
                    client.Notify("FameBot is now active");
                    break;
                case "start":
                    Start();
                    client.Notify("FameBot is starting");
                    break;
            }
        }

        private void GuiEventCallback(GuiEvent evt)
        {
            switch (evt)
            {
                case GuiEvent.StartBot:

                    break;
                case GuiEvent.StopBot:
                    Stop();
                    break;
            }
        }

        private void Stop()
        {
            followTarget = false;
            targets.Clear();
        }

        private void Start()
        {
            targets.Clear();
            followTarget = true;
        }

        private void Escape(Client client)
        {
            Console.WriteLine("[FameBot] Escaping to nexus.");
            client.SendToServer(Packet.Create(PacketType.ESCAPE));
        }

        #region PacketHookMethods
        private void OnUpdate(Client client, Packet p)
        {
            UpdatePacket packet = p as UpdatePacket;

            // Get new info
            foreach(Entity obj in packet.NewObjs)
            {
                if(Enum.IsDefined(typeof(Classes), obj.ObjectType))
                {
                    PlayerData playerData = new PlayerData(obj.Status.ObjectId);
                    playerData.Class = (Classes)obj.ObjectType;
                    playerData.Pos = obj.Status.Position;
                    foreach(var data in obj.Status.Data)
                    {
                        playerData.Parse(data.Id, data.IntValue, data.StringValue);
                    }

                    if (playerPosisions.ContainsKey(obj.Status.ObjectId))
                        playerPosisions.Remove(obj.Status.ObjectId);
                    playerPosisions.Add(obj.Status.ObjectId, new Target(obj.Status.ObjectId, playerData.Name, playerData.Pos));

                    // TODO: add portals. (object id 1810)
                }
            }

            // Remove old info
            foreach (int dropId in packet.Drops)
            {
                if (playerPosisions.ContainsKey(dropId))
                {
                    if(followTarget && targets.Exists(t => t.ObjectId == dropId))
                    {
                        targets.Remove(targets.Find(t => t.ObjectId == dropId));
                        if(targets.Count > 0)
                        {
                            Console.WriteLine("[FameBot] The player \"{0}\" was dropped from the target list.", playerPosisions[dropId].Name);
                        } else
                        {
                            Console.WriteLine("[FameBot] There are no players left in the target list.");
                            if (escapeIfNoTargets)
                                Escape(client);
                        }
                    }
                    playerPosisions.Remove(dropId);
                }
            }
        }

        private void OnNewTick(Client client, Packet p)
        {
            NewTickPacket packet = p as NewTickPacket;
            tickCount++;

            // Autonexus
            float healthPercentage = (float)client.PlayerData.Health / (float)client.PlayerData.MaxHealth;
            healthChanged?.Invoke(this, new HealthChangedEventArgs(healthPercentage * 100f));
            if (healthPercentage < autoNexusThreshold)
                Escape(client);

            if(tickCount % tickCountThreshold == 0)
            {
                if (followTarget && playerPosisions.Count > 0)
                {
                    List<Target> newTargets = D36n4.Invoke(playerPosisions.Values.ToList());
                    if(newTargets == null)
                    {
                        targets.Clear();
                        Console.WriteLine("[FameBot] Player search didn't return any good results");
                    } else
                    {
                        targets = newTargets;
                        Console.WriteLine("[FameBot] Now targeting {0} players", targets.Count);
                    }
                }
                tickCount = 0;
            }

            // Update player positions
            foreach(Status status in packet.Statuses)
            {
                if (playerPosisions.ContainsKey(status.ObjectId))
                    playerPosisions[status.ObjectId].UpdatePosition(status.Position);
            }
            
            if(!followTarget)
            {
                if (W_PRESSED)
                {
                    W_PRESSED = false;
                    PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.W, 0);
                }
                if (A_PRESSED)
                {
                    A_PRESSED = false;
                    PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.A, 0);
                }
                if (S_PRESSED)
                {
                    S_PRESSED = false;
                    PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.S, 0);
                }
                if (D_PRESSED)
                {
                    D_PRESSED = false;
                    PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.D, 0);
                }
            }

            if(followTarget && targets.Count > 0)
            {
                var targetPosition = new Location(targets.Average(t => t.Position.X), targets.Average(t => t.Position.Y));

                if (client.PlayerData.Pos.DistanceTo(targetPosition) > teleportDistanceThreshold)
                {
                    //TeleportPacket tpPacket = Packet.Create(PacketType.TELEPORT) as TeleportPacket;
                    //tpPacket.ObjectId = targets.OrderBy(t => t.Position.DistanceTo(targetPosition)).First().ObjectId;
                    //client.SendToServer(tpPacket);
                }

                #region Movement
                // Left or right
                if (client.PlayerData.Pos.X < targetPosition.X - followDistanceThreshold)
                {
                    // Move right
                    if (!D_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyDown, (int)Key.D, 0);
                        D_PRESSED = true;
                    }
                    if (A_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.A, 0);
                        A_PRESSED = false;
                    }
                }
                else if (client.PlayerData.Pos.X <= targetPosition.X + followDistanceThreshold)
                {
                    if (D_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.D, 0);
                        D_PRESSED = false;
                    }
                }
                if (client.PlayerData.Pos.X > targetPosition.X + followDistanceThreshold)
                {
                    // Move left
                    if (!A_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyDown, (int)Key.A, 0);
                        A_PRESSED = true;
                    }
                    if (D_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.D, 0);
                        D_PRESSED = false;
                    }
                }
                else if (client.PlayerData.Pos.X >= targetPosition.X - followDistanceThreshold)
                {
                    if (A_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.A, 0);
                        A_PRESSED = false;
                    }
                }

                // Up or down
                if (client.PlayerData.Pos.Y < targetPosition.Y - followDistanceThreshold)
                {
                    // Move down
                    if (!S_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyDown, (int)Key.S, 0);
                        S_PRESSED = true;
                    }
                    if (W_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.W, 0);
                        W_PRESSED = false;
                    }
                }
                else if (client.PlayerData.Pos.Y <= targetPosition.Y + followDistanceThreshold)
                {
                    if (S_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.S, 0);
                        S_PRESSED = false;
                    }
                }
                if (client.PlayerData.Pos.Y > targetPosition.Y + followDistanceThreshold)
                {
                    // Move up
                    if (!W_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyDown, (int)Key.W, 0);
                        W_PRESSED = true;
                    }
                    if (S_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.S, 0);
                        S_PRESSED = false;
                    }
                }
                else if (client.PlayerData.Pos.Y >= targetPosition.Y - followDistanceThreshold)
                {
                    if (W_PRESSED)
                    {
                        PostMessage(flashPtr, (uint)Key.KeyUp, (int)Key.W, 0);
                        W_PRESSED = false;
                    }
                }
                #endregion
            }
        }
        #endregion
    }
}
