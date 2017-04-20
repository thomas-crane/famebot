using Lib_K_Relay.Networking;
using Lib_K_Relay.Networking.Packets.Server;
using Lib_K_Relay.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Helpers
{
    public static class ClientExtensions
    {
        public static void Notify(this Client client, string text)
        {
            client.SendToClient(PluginUtils.CreateNotification(client.ObjectId, text));
        }

        public static bool ConnectTo(this Client client, ReconnectPacket packet)
        {
            if (packet == null)
                return false;
            string host = packet.Host;
            int port = packet.Port;
            byte[] key = packet.Key;
            client.State.ConTargetAddress = host;
            client.State.ConTargetPort = port;
            client.State.ConRealKey = key;
            packet.Key = Encoding.UTF8.GetBytes(client.State.GUID);
            packet.Host = "localhost";
            packet.Port = 2050;

            client.SendToClient(packet);

            packet.Key = key;
            packet.Host = host;
            packet.Port = port;
            return true;
        }
    }
}
