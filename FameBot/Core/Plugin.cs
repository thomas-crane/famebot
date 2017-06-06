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
using Lib_K_Relay.GameData;
using FameBot.Services;
using FameBot.UserInterface;
using FameBot.Data.Events;
using System.Drawing;

namespace FameBot.Core
{
    public class Plugin : IPlugin
    {
        #region IPlugin
        public string GetAuthor()
        {
            return "tcrane";
        }

        public string[] GetCommands()
        {
            return new string[]
            {
                "/bind - binds the bot to the client where the command is used.",
                "/start - starts the bot",
                "/gui - opens the gui"
            };
        }

        public string GetDescription()
        {
            return "A bot designed to automate the process of collecting fame.";
        }

        public string GetName()
        {
            return "FameBot by tcrane";
        }
        #endregion

        private static Configuration config;
        public static Configuration Config
        {
            get { return config; }
        }
        private FameBotGUI gui;

        private Dictionary<string, Player> players;
        private List<Client> connectionQueue;
        private List<Tuple<Client, MapInfoPacket>> mapInfoPacketQueue;
        private Dictionary<string, MapInfoPacket> mapInfoPacketBacklog;

        public static event HealthEventHandler healthChanged;
        public delegate void HealthEventHandler(object sender, HealthChangedEventArgs args);

        public static event KeyEventHandler keyChanged;
        public delegate void KeyEventHandler(object sender, KeyEventArgs args);

        private static event GuiEventHandler guiEvent;
        private delegate void GuiEventHandler(GuiEvent evt, Player clientName);

        public static event LogEventHandler logEvent;
        public delegate void LogEventHandler(object sender, LogEventArgs args);

        private static event SendMessageEventHandler sendMessage;
        private delegate void SendMessageEventHandler(string message);

        public static event ReceiveMessageEventHandler receiveMesssage;
        public delegate void ReceiveMessageEventHandler(object sender, MessageEventArgs args);

        public static event FameUpdateEventHandler fameUpdate;
        public delegate void FameUpdateEventHandler(object sender, FameUpdateEventArgs args);

        #region WINAPI
        // Get the focused window.
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();
        // Send a message to a specific process via the handle.
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        // Gets the positions of the corners of a window via the MainWindowHandle.
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        // Converts a point in screen space to a point relative to hWnd's window.
        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
        #endregion

        #region Keys
        #endregion

        public void Initialize(Proxy proxy)
        {
            players = new Dictionary<string, Player>();
            connectionQueue = new List<Client>();
            mapInfoPacketQueue = new List<Tuple<Client, MapInfoPacket>>();
            mapInfoPacketBacklog = new Dictionary<string, MapInfoPacket>();

            gui = new FameBotGUI();
            PluginUtils.ShowGUI(gui);

            config = ConfigManager.GetConfiguration();

            Log("Using multi-client bot. Each client must be bound individually before starting!");

            proxy.HookCommand("bind", ReceiveCommand);
            proxy.HookCommand("start", ReceiveCommand);
            proxy.HookCommand("gui", ReceiveCommand);

            proxy.HookPacket(PacketType.UPDATE, OnUpdate);
            proxy.HookPacket(PacketType.NEWTICK, OnNewTick);
            proxy.HookPacket(PacketType.PLAYERHIT, OnHit);
            proxy.HookPacket(PacketType.MAPINFO, OnMapInfo);
            proxy.HookPacket(PacketType.TEXT, OnText);

            proxy.ClientConnected += (client) =>
            {
                AddToConnectionQueue(client);
            };

            proxy.ClientDisconnected += (client) =>
            {
                var player = players[client.PlayerData.Name];
                Log("Client {0} disconnected. Waiting a few seconds before trying to press play...", client.PlayerData.Name);
                PressPlay(player);
            };

            guiEvent += (evt, player) =>
            {
                switch (evt)
                {
                    case GuiEvent.StartBot:
                        Start(player);
                        break;
                    case GuiEvent.StopBot:
                        Stop(player);
                        break;
                    case GuiEvent.SettingsChanged:
                        config = ConfigManager.GetConfiguration();
                        break;
                }
            };

            //sendMessage += (message) =>
            //{
            //    if (!(connectedClient?.Connected ?? false))
            //        return;
            //    PlayerTextPacket packet = (PlayerTextPacket)Packet.Create(PacketType.PLAYERTEXT);
            //    packet.Text = message;
            //    connectedClient.SendToServer(packet);
            //};
        }

        private void ReceiveCommand(Client client, string cmd, string[] args)
        {
            if (!players.ContainsKey(client.PlayerData.Name))
                players.Add(client.PlayerData.Name, new Player(client));
            var player = players[client.PlayerData.Name];
            if(mapInfoPacketBacklog.ContainsKey(player.Name))
            {
                player.HandleMapInfoPacket(mapInfoPacketBacklog[player.Name]);
                mapInfoPacketBacklog.Remove(player.Name);
            }
            switch (cmd)
            {
                case "bind":
                    var ptr = GetForegroundWindow();
                    gui.AddClient(player);
                    player.SetHandle(ptr);
                    foreach(var p in players.Keys)
                    {
                        Console.WriteLine(p);
                    }
                    client.Notify("FameBot is now active");
                    break;
                case "start":
                    Start(player);
                    client.Notify("FameBot is starting");
                    break;
                case "gui":
                    if (gui == null)
                        gui = new FameBotGUI();
                    gui.Show();
                    break;
            }
        }

        public static void InvokeGuiEvent(GuiEvent evt, Player player)
        {
            guiEvent?.Invoke(evt, player);
        }

        public static void InvokeSendMessageEvent(string message)
        {
            sendMessage?.Invoke(message);
        }

        private void Stop(Player player)
        {
            if (!player.Enabled)
                return;
            Log("Stopping bot.");
            player.FollowTarget = false;
            player.GotoRealm = false;
            player.Targets.Clear();
            player.Enabled = false;
            player.IsInNexus = false;
        }

        private void Start(Player player)
        {
            Console.WriteLine("Starting player: {0}", player.Client.PlayerData.Name);
            if (player.Enabled)
                return;
            Log("Starting client {0}.", player.Client.PlayerData.Name);
            player.Targets.Clear();
            player.Enabled = true;
            if (player.CurrentMapName == null)
                return;
            if (player.IsInNexus && config.AutoConnect)
            {
                player.GotoRealm = true;
                player.FollowTarget = false;
                if(player.Client != null)
                    player.MoveToRealms();
            }
            else
            {
                player.GotoRealm = false;
                player.FollowTarget = true;
            }
        }

        public static void Log(string message)
        {
            logEvent?.Invoke(null, new LogEventArgs(message));
        }
        public static void Log(string message, params object[] args)
        {
            string m = string.Format(message, args);
            logEvent?.Invoke(null, new LogEventArgs(m));
        }

        private async void PressPlay(Player player)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));

            if (!config.AutoConnect)
                return;
            if (!player.Enabled)
                return;

            if ((player.Client?.Connected ?? false))
            {
                Log("Client {0} is connected. No need to press play.", player.Client.PlayerData.Name);
                return;
            }
            else
                Log("Client still not connected. Pressing play button...");

            // Get the window details before pressing the button in case
            // it has changed size or position on the desktop.
            RECT windowRect = new RECT();
            GetWindowRect(player.WindowHandle, ref windowRect);
            var size = windowRect.GetSize();

            // The play button is located half way across the
            // window and roughly 92% of the way to the bottom.
            int playButtonX = size.Width / 2 + windowRect.Left;
            int playButtonY = (int)((double)size.Height * 0.92) + windowRect.Top;

            // Convert the screen point to a window point
            POINT relativePoint = new POINT(playButtonX, playButtonY);
            ScreenToClient(player.WindowHandle, ref relativePoint);

            // Press the buttons.
            SendMessage(player.WindowHandle, (uint)MouseButton.LeftButtonDown, new IntPtr(0x1), new IntPtr((relativePoint.Y << 16) | (relativePoint.X & 0xFFFF)));
            SendMessage(player.WindowHandle, (uint)MouseButton.LeftButtonUp, new IntPtr(0x1), new IntPtr((relativePoint.Y << 16) | (relativePoint.X & 0xFFFF)));

            PressPlay(player);
        }

        #region PacketHookMethods
        private void OnUpdate(Client client, Packet p)
        {
            if (!players.ContainsKey(client.PlayerData.Name))
                return;
            var player = players[client.PlayerData.Name];
            UpdatePacket packet = p as UpdatePacket;
            player.HandleUpdatePacket(packet);
        }

        private void OnMapInfo(Client client, Packet p)
        {
            AddToMapInfoPacketQueue(new Tuple<Client, MapInfoPacket>(client, p as MapInfoPacket));
        }

        private void OnHit(Client client, Packet p)
        {
            if (!players.ContainsKey(client.PlayerData.Name))
                return;
            var player = players[client.PlayerData.Name];

            float healthPercentage = (float)player.Client.PlayerData.Health / (float)player.Client.PlayerData.MaxHealth * 100f;
            if (healthPercentage < config.AutonexusThreshold * 1.25f)
                Log(string.Format("{0} Health at {1}%", player.Client.PlayerData.Name, (int)(healthPercentage)));
        }

        private void OnNewTick(Client client, Packet p)
        {
            if (!players.ContainsKey(client.PlayerData.Name))
                return;
            var player = players[client.PlayerData.Name];
            NewTickPacket packet = p as NewTickPacket;
            player.HandleNewTickPacket(packet);
        }

        private void OnText(Client client, Packet p)
        {
            TextPacket packet = p as TextPacket;
            if (packet.Name == client.PlayerData?.Name || packet.NumStars < 1)
                return;
            receiveMesssage?.Invoke(this, new MessageEventArgs(packet.Text, packet.Name, packet.Recipient == client.PlayerData?.Name ? true : false));
        }
        #endregion

        private void AddToConnectionQueue(Client client)
        {
            lock(connectionQueue)
            {
                if (connectionQueue.Count == 0)
                {
                    connectionQueue.Add(client);
                    ProcessConnectionQueue();
                }
                else
                {
                    connectionQueue.Add(client);
                }
            }
        }

        private async void ProcessConnectionQueue()
        {
            bool keepProcessing = false;
            lock (connectionQueue)
            {
                if(connectionQueue.Any(c => c.PlayerData != null))
                {
                    foreach(Client client in connectionQueue)
                    {
                        if (client.PlayerData != null)
                        {
                            if (!players.ContainsKey(client.PlayerData.Name))
                            {
                                Log("Client connected but isn't bound");
                                foreach (var p in players.Keys)
                                {
                                    Console.WriteLine(p);
                                }
                            }
                            else
                            {
                                var player = players[client.PlayerData.Name];
                                player.Targets.Clear();
                                player.PlayerPositions.Clear();
                                player.Enemies.Clear();
                                player.Rocks.Clear();
                                player.FollowTarget = false;
                                player.IsInNexus = false;
                            }
                        }
                    }
                    connectionQueue.RemoveAll(c => c.PlayerData != null);
                }
                if(connectionQueue.Count > 0)
                {
                    keepProcessing = true;
                }
            }
            if(keepProcessing)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(10));
                ProcessConnectionQueue();
            }
        }

        private void AddToMapInfoPacketQueue(Tuple<Client, MapInfoPacket> kvp)
        {
            lock (mapInfoPacketQueue)
            {
                if (mapInfoPacketQueue.Count == 0)
                {
                    mapInfoPacketQueue.Add(kvp);
                    ProcessMapInfoPacketQueue();
                }
                else
                {
                    mapInfoPacketQueue.Add(kvp);
                }
            }
        }

        private async void ProcessMapInfoPacketQueue()
        {
            bool keepProcessing = false;
            lock (mapInfoPacketQueue)
            {
                if (mapInfoPacketQueue.Any(c => c.Item1.PlayerData != null))
                {
                    foreach (Tuple<Client, MapInfoPacket> kvp in mapInfoPacketQueue)
                    {
                        var client = kvp.Item1;
                        if (client.PlayerData != null)
                        {
                            if (!players.ContainsKey(client.PlayerData.Name))
                            {
                                Console.WriteLine("Adding to map info backlog");
                                foreach (var p in players.Keys)
                                {
                                    Console.WriteLine(p);
                                }
                                Console.WriteLine("Client key: " + client.PlayerData.Name);
                                mapInfoPacketBacklog.Add(client.PlayerData.Name, kvp.Item2);
                            }
                            else
                            {
                                Console.WriteLine("Client already bound");
                                var player = players[client.PlayerData.Name];
                                player.HandleMapInfoPacket(kvp.Item2);
                            }
                        }
                    }
                    mapInfoPacketQueue.RemoveAll(c => c.Item1.PlayerData != null);
                }
                if (mapInfoPacketQueue.Count > 0)
                {
                    keepProcessing = true;
                }
                Console.WriteLine("Count map info: {0}", mapInfoPacketQueue.Count);
            }
            if (keepProcessing)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(10));
                ProcessMapInfoPacketQueue();
            }
        }
    }
}
