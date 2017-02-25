using Lib_K_Relay.Networking;
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
    }
}
