using FameBot.Core;
using FameBot.Data.Enums;
using FameBot.Helpers;
using FameBot.Services;
using Lib_K_Relay.GameData;
using Lib_K_Relay.Networking;
using Lib_K_Relay.Networking.Packets;
using Lib_K_Relay.Networking.Packets.Client;
using Lib_K_Relay.Networking.Packets.DataObjects;
using Lib_K_Relay.Networking.Packets.Server;
using Lib_K_Relay.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Models
{
    public class Player
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private Client client;
        public Client Client
        {
            get { return client; }
        }

        private IntPtr hWnd;
        public IntPtr WindowHandle
        {
            get { return hWnd; }
        }

        private bool handleSet = false;
        public bool HandleSet
        {
            get { return handleSet; }
        }

        public List<Portal> Portals { get; set; }
        public List<Target> Targets { get; set; }
        public Dictionary<int, Target> PlayerPositions { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Rock> Rocks { get; set; }
        public int TickCount { get; set; }

        public bool FollowTarget { get; set; }
        public bool GotoRealm { get; set; }
        public bool Enabled { get; set; }
        public bool IsInNexus { get; set; }
        public string CurrentMapName { get; set; }

        #region Keys
        private bool wPressed;
        private bool aPressed;
        private bool sPressed;
        private bool dPressed;

        private bool W_PRESSED
        {
            get { return wPressed; }
            set
            {
                if (wPressed == value)
                    return;
                wPressed = value;
                Plugin.SendMessage(hWnd, value ? (uint)Key.KeyDown : (uint)Key.KeyUp, new IntPtr((int)Key.W), IntPtr.Zero);
                //keyChanged?.Invoke(this, new KeyEventArgs(Key.W, value));
            }
        }
        private bool A_PRESSED
        {
            get { return aPressed; }
            set
            {
                if (aPressed == value)
                    return;
                aPressed = value;
                Plugin.SendMessage(hWnd, value ? (uint)Key.KeyDown : (uint)Key.KeyUp, new IntPtr((int)Key.A), IntPtr.Zero);
                //keyChanged?.Invoke(this, new KeyEventArgs(Key.A, value));
            }
        }
        private bool S_PRESSED
        {
            get { return sPressed; }
            set
            {
                if (sPressed == value)
                    return;
                sPressed = value;
                Plugin.SendMessage(hWnd, value ? (uint)Key.KeyDown : (uint)Key.KeyUp, new IntPtr((int)Key.S), IntPtr.Zero);
                //keyChanged?.Invoke(this, new KeyEventArgs(Key.S, value));
            }
        }
        private bool D_PRESSED
        {
            get { return dPressed; }
            set
            {
                if (dPressed == value)
                    return;
                dPressed = value;
                Plugin.SendMessage(hWnd, value ? (uint)Key.KeyDown : (uint)Key.KeyUp, new IntPtr((int)Key.D), IntPtr.Zero);
                //keyChanged?.Invoke(this, new KeyEventArgs(Key.D, value));
            }
        }
        #endregion

        public Player(Client client)
        {
            this.client = client;
            this.name = client.PlayerData.Name;

            Portals = new List<Portal>();
            Targets = new List<Target>();
            PlayerPositions = new Dictionary<int, Target>();
            Enemies = new List<Enemy>();
            Rocks = new List<Rock>();
        }

        public void SetHandle(IntPtr handle)
        {
            this.hWnd = handle;
            handleSet = true;
        }

        public void HandleUpdatePacket(UpdatePacket packet)
        {
            // Get new info
            foreach (Entity obj in packet.NewObjs)
            {
                if (obj.ObjectType == 1810)
                {
                    foreach (var data in obj.Status.Data)
                    {
                        if (data.StringValue != null)
                        {
                            var strArray = data.StringValue.Split(' ');
                            var strCount = strArray[1].Split('/')[0].Remove(0, 1);
                            var name = strArray[0].Split('.')[1];
                            var portal = new Portal(obj.Status.ObjectId, int.Parse(strCount), name, obj.Status.Position);
                            if (Portals.Exists(ptl => ptl.ObjectId == obj.Status.ObjectId))
                                Portals.RemoveAll(ptl => ptl.ObjectId == obj.Status.ObjectId);

                            Portals.Add(portal);
                        }
                    }
                }
            }

            // Remove old info
            foreach (int dropId in packet.Drops)
            {
                if (PlayerPositions.ContainsKey(dropId))
                {
                    if (FollowTarget && Targets.Exists(t => t.ObjectId == dropId))
                    {
                        Targets.Remove(Targets.Find(t => t.ObjectId == dropId));
                        if (Targets.Count > 0)
                        {
                            Plugin.Log(string.Format("Dropping \"{0}\" from targets.", PlayerPositions[dropId].Name));
                        }
                        else
                        {
                            Plugin.Log("No targets left in target list.");
                            if (Plugin.Config.EscapeIfNoTargets)
                                Escape();
                        }
                    }
                    PlayerPositions.Remove(dropId);
                }
                if (Portals.Exists(ptl => ptl.ObjectId == dropId))
                    Portals.RemoveAll(ptl => ptl.ObjectId == dropId);
            }
        }

        public void HandleMapInfoPacket(MapInfoPacket packet)
        {
            Console.WriteLine("{0} Got MapInfo: {1}", name, packet.Name);
            if (packet == null)
                return;
            Portals.Clear();
            CurrentMapName = packet.Name;
            if (packet.Name == "Oryx's Castle" && Enabled)
            {
                Plugin.Log("Escaping from oryx's castle.");
                Escape();
                return;
            }
            if (packet.Name == "Nexus" && Plugin.Config.AutoConnect && Enabled)
            {
                IsInNexus = true;
                GotoRealm = true;
                MoveToRealms();
            }
            else
            {
                Console.WriteLine("Enabled is = {0}", Enabled);
                IsInNexus = false;
                GotoRealm = false;
                if (Enabled)
                    FollowTarget = true;
            }
        }

        public void HandleNewTickPacket(NewTickPacket packet)
        {
            TickCount++;

            // Health changed event
            float healthPercentage = (float)client.PlayerData.Health / (float)client.PlayerData.MaxHealth * 100f;
            //healthChanged?.Invoke(this, new HealthChangedEventArgs(healthPercentage));

            // Autonexus
            if (healthPercentage < Plugin.Config.AutonexusThreshold && !(CurrentMapName?.Equals("Nexus") ?? false) && Enabled)
                Escape();

            // Fame event
            //fameUpdate?.Invoke(this, new FameUpdateEventArgs(player.client.PlayerData?.CharacterFame ?? -1, player.client.PlayerData?.CharacterFameGoal ?? -1));

            if (TickCount % Plugin.Config.TickCountThreshold == 0)
            {
                if (FollowTarget && PlayerPositions.Count > 0 && !GotoRealm)
                {
                    List<Target> newTargets = D36n4.Invoke(PlayerPositions.Values.ToList(), Plugin.Config.Epsilon, Plugin.Config.MinPoints, Plugin.Config.FindClustersNearCenter);
                    if (newTargets == null)
                    {
                        if (Targets.Count != 0 && Plugin.Config.EscapeIfNoTargets)
                            Escape();
                        Targets.Clear();
                        Plugin.Log("[{0}] No valid clusters found.", client.PlayerData.Name);
                    }
                    else
                    {
                        if (Targets.Count != newTargets.Count)
                            Plugin.Log(string.Format("Now targeting {0} players.", newTargets.Count));
                        Targets = newTargets;
                    }
                }
                TickCount = 0;
            }

            // Updates
            foreach (Status status in packet.Statuses)
            {
                // Update player positions
                if (PlayerPositions.ContainsKey(status.ObjectId))
                    PlayerPositions[status.ObjectId].UpdatePosition(status.Position);

                // Update enemy positions
                if (Enemies.Exists(en => en.ObjectId == status.ObjectId))
                    Enemies.Find(en => en.ObjectId == status.ObjectId).Location = status.Position;

                // Update portal player counts when in nexus.
                if (Portals.Exists(ptl => ptl.ObjectId == status.ObjectId) && (IsInNexus))
                {
                    foreach (var data in status.Data)
                    {
                        if (data.StringValue != null)
                        {
                            var strCount = data.StringValue.Split(' ')[1].Split('/')[0].Remove(0, 1);
                            Portals[Portals.FindIndex(ptl => ptl.ObjectId == status.ObjectId)].PlayerCount = int.Parse(strCount);
                        }
                    }
                }

                // Change the speed if in Nexus
                if (IsInNexus && status.ObjectId == client.ObjectId)
                {
                    foreach (var data in status.Data)
                    {
                        if (data.Id == StatsType.Speed)
                        {
                            if (data.IntValue > 45)
                            {
                                List<StatData> list = new List<StatData>(status.Data) {
                                    new StatData {
                                        Id = StatsType.Speed, IntValue = 45
                                    }
                                };
                                status.Data = list.ToArray();
                            }
                        }
                    }
                }
            }

            if (!FollowTarget && !GotoRealm)
            {
                W_PRESSED = false;
                A_PRESSED = false;
                S_PRESSED = false;
                D_PRESSED = false;
            }

            if (FollowTarget && Targets.Count > 0)
            {
                var targetPosition = new Location(Targets.Average(t => t.Position.X), Targets.Average(t => t.Position.Y));

                if (client.PlayerData.Pos.DistanceTo(targetPosition) > Plugin.Config.TeleportDistanceThreshold)
                {
                    var name = Targets.OrderBy(t => t.Position.DistanceTo(targetPosition)).First().Name;
                    if (name != client.PlayerData.Name)
                    {
                        var tpPacket = (PlayerTextPacket)Packet.Create(PacketType.PLAYERTEXT);
                        tpPacket.Text = "/teleport " + name;
                        client.SendToServer(tpPacket);
                    }
                }

                if (Enemies.Exists(en => en.Location.DistanceSquaredTo(client.PlayerData.Pos) <= 49))
                {
                    Location closestEnemy = Enemies.OrderBy(en => en.Location.DistanceSquaredTo(client.PlayerData.Pos)).First().Location;

                    double angle = Math.Atan2(client.PlayerData.Pos.Y - closestEnemy.Y, client.PlayerData.Pos.X - closestEnemy.X);

                    float newX = closestEnemy.X + 8f * (float)Math.Cos(angle);
                    float newY = closestEnemy.Y + 8f * (float)Math.Sin(angle);

                    var avoidPos = new Location(newX, newY);
                    CalculateMovement(avoidPos, Plugin.Config.FollowDistanceThreshold);
                    return;
                }

                if (Rocks.Exists(rock => rock.Location.DistanceSquaredTo(client.PlayerData.Pos) <= 4))
                {
                    Location closestRock = Rocks.OrderBy(rock => rock.Location.DistanceSquaredTo(client.PlayerData.Pos)).First().Location;
                    double angleDifference = client.PlayerData.Pos.GetAngleDifferenceDegrees(targetPosition, closestRock);

                    if (Math.Abs(angleDifference) < 70.0)
                    {
                        double angle = Math.Atan2(client.PlayerData.Pos.Y - closestRock.Y, client.PlayerData.Pos.X - closestRock.X);
                        if (angleDifference <= 0)
                            angle += (Math.PI / 2); // add 90 degrees to the angle to go clockwise around the rock.
                        if (angleDifference > 0)
                            angle -= (Math.PI / 2); // remove 90 degrees from the angle to go anti-clockwise around the rock.

                        float newX = closestRock.X + 2f * (float)Math.Cos(angle);
                        float newY = closestRock.Y + 2f * (float)Math.Sin(angle);

                        var avoidRockPos = new Location(newX, newY);
                        CalculateMovement(avoidRockPos, 0.5f);
                        return;
                    }
                }

                CalculateMovement(targetPosition, Plugin.Config.FollowDistanceThreshold);
            }
        }

        private void Escape()
        {
            Plugin.Log("Escaping to nexus.");
            client.SendToServer(Packet.Create(PacketType.ESCAPE));
        }

        //public void SetKeyState(Key key, Key state)
        //{
        //    Console.WriteLine("Setting Key");
        //    if (!HandleSet)
        //    {
        //        Console.WriteLine("Handle Not Set");
        //        return;
        //    }
        //    Plugin.SendMessage(WindowHandle, (uint)state, new IntPtr((int)key), IntPtr.Zero);
        //    //keyChanged?.Invoke(this, new KeyEventArgs(Key.W, state == Key.KeyUp ? false : true));
        //}

        private void CalculateMovement(Location targetPosition, float tolerance)
        {
            // Left or right
            if (client.PlayerData.Pos.X < targetPosition.X - tolerance)
            {
                // Move right
                //SetKeyState(Key.D, Key.KeyDown);
                //SetKeyState(Key.A, Key.KeyUp);
                D_PRESSED = true;
                A_PRESSED = false;
            }
            else if (client.PlayerData.Pos.X <= targetPosition.X + tolerance)
            {
                // Stop moving
                //SetKeyState(Key.D, Key.KeyUp);
                D_PRESSED = false;
            }
            if (client.PlayerData.Pos.X > targetPosition.X + tolerance)
            {
                // Move left
                //SetKeyState(Key.A, Key.KeyDown);
                //SetKeyState(Key.D, Key.KeyUp);
                A_PRESSED = true;
                D_PRESSED = false;
            }
            else if (client.PlayerData.Pos.X >= targetPosition.X - tolerance)
            {
                // Stop moving
                //SetKeyState(Key.A, Key.KeyUp);
                A_PRESSED = false;
            }

            // Up or down
            if (client.PlayerData.Pos.Y < targetPosition.Y - tolerance)
            {
                // Move down
                //SetKeyState(Key.S, Key.KeyDown);
                //SetKeyState(Key.W, Key.KeyUp);
                S_PRESSED = true;
                W_PRESSED = false;
            }
            else if (client.PlayerData.Pos.Y <= targetPosition.Y + tolerance)
            {
                // Stop moving
                //SetKeyState(Key.S, Key.KeyUp);
                S_PRESSED = false;
            }
            if (client.PlayerData.Pos.Y > targetPosition.Y + tolerance)
            {
                // Move up
                //SetKeyState(Key.W, Key.KeyDown);
                //SetKeyState(Key.S, Key.KeyUp);
                W_PRESSED = true;
                S_PRESSED = false;
            }
            else if (client.PlayerData.Pos.Y >= targetPosition.Y - tolerance)
            {
                // Stop moving
                //SetKeyState(Key.W, Key.KeyUp);
                W_PRESSED = false;
            }
        }

        private async void AttemptConnection(int portalId)
        {
            UsePortalPacket packet = (UsePortalPacket)Packet.Create(PacketType.USEPORTAL);
            packet.ObjectId = portalId;

            if (!Portals.Exists(ptl => ptl.ObjectId == portalId))
            {
                GotoRealm = true;
                MoveToRealms();
                return;
            }

            var pCount = Portals.Find(p => p.ObjectId == portalId).PlayerCount;
            if (client.Connected && pCount < 85)
                client.SendToServer(packet);
            await Task.Delay(TimeSpan.FromSeconds(0.2));
            if (client.Connected && Enabled)
                AttemptConnection(portalId);
            else if (Enabled)
                Plugin.Log("[{0}] Connection successful.", client.PlayerData.Name);
            else
                Plugin.Log("Bot disabled, cancelling connection attempt.");
        }

        public async void MoveToRealms()
        {
            if (client == null)
            {
                Plugin.Log("Client {0} Not bound yet", client.PlayerData.Name);
                return;
            }

            Location target = new Location(159, 101);

            if (client.PlayerData == null)
            {
                await Task.Delay(5);
                MoveToRealms();
                return;
            }

            var healthPercentage = (float)client.PlayerData.Health / (float)client.PlayerData.MaxHealth;
            if (healthPercentage < 0.95f)
                target = new Location(159, 127);

            string bestName = "";
            if (client.PlayerData.Pos.Y <= 110 && client.PlayerData.Pos.Y != 0)
            {
                if (Portals.Count != 0)
                {
                    int bestCount = 0;
                    if (Portals.Where(ptl => ptl.PlayerCount == 85).Count() > 1)
                    {
                        foreach (Portal ptl in Portals.Where(ptl => ptl.PlayerCount == 85))
                        {
                            int count = PlayerPositions.Values.Where(plr => plr.Position.DistanceSquaredTo(ptl.Location) <= 4).Count();
                            if (count > bestCount)
                            {
                                bestCount = count;
                                bestName = ptl.Name;
                                target = ptl.Location;
                            }
                        }
                    }
                    else
                    {
                        Portal ptl = Portals.OrderByDescending(prtl => prtl.PlayerCount).First();
                        target = ptl.Location;
                        bestName = ptl.Name;
                    }
                }
                else
                    target = new Location(159, 101);
            }

            CalculateMovement(target, 0.5f);

            if (client.PlayerData.Pos.DistanceTo(target) < 1f && Portals.Count != 0)
            {
                if (client.State.LastRealm?.Name.Contains(bestName) ?? false)
                {
                    Plugin.Log("Last realm is still the best realm. Sending reconnect.");
                    if (client.ConnectTo(client.State.LastRealm))
                    {
                        GotoRealm = false;
                        return;
                    }
                }

                Plugin.Log("Attempting connection.");
                GotoRealm = false;
                AttemptConnection(Portals.OrderBy(ptl => ptl.Location.DistanceSquaredTo(client.PlayerData.Pos)).First().ObjectId);
            }
            await Task.Delay(5);
            if (GotoRealm)
            {
                MoveToRealms();
            }
            else
            {
                Plugin.Log("Stopped moving to realm.");
            }
        }
    }
}
