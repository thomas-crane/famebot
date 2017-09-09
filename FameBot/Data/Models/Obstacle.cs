using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_K_Relay.Networking.Packets.DataObjects;

namespace FameBot.Data.Models
{
    public class Obstacle
    {
        public int ObjectId { get; set; }
        public Location Location { get; set; }

        public Obstacle(int objectId, Location location)
        {
            ObjectId = objectId;
            Location = location;
        }
    }
}
