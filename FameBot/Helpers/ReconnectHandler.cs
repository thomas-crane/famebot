using System.Net;
using System.Text;
using Lib_K_Relay;
using Lib_K_Relay.Networking;
using Lib_K_Relay.Networking.Packets;
using Lib_K_Relay.Networking.Packets.Server;

namespace FameBot.Helpers
{
    public class ReconnectHandler
    {
        public void Attach(Proxy proxy) {
            proxy.HookPacket<ReconnectPacket>(OnReconnect);
        }

        private void OnReconnect(Client client, ReconnectPacket packet) {
            //Stuff
        }

        public void SendReconnect(Client client, Packet packet) {
            ReconnectPacket reconnect = packet as ReconnectPacket;
            string host = reconnect.Host;
            int port = reconnect.Port;
            byte[] key = reconnect.Key;
            client.State.ConTargetAddress = host;
            client.State.ConTargetPort = port;
            client.State.ConRealKey = key;
            reconnect.Key = Encoding.UTF8.GetBytes(client.State.GUID);
            reconnect.Host = "localhost";
            reconnect.Port = 2050;

            client.SendToClient(reconnect);

            reconnect.Key = key;
            reconnect.Host = host;
            reconnect.Port = port;
        }
    }
}