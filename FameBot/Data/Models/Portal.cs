using Lib_K_Relay.Networking.Packets.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Models
{
    public class Portal
    {
        public int ObjectId { get; set; }
        public int PlayerCount { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public bool Connected { get; set; }

        public Portal(int objectId, int playerCount, string name, Location location)
        {
            ObjectId = objectId;
            PlayerCount = playerCount;
            Name = name;
            Location = location;
        }
    }
}
