using Lib_K_Relay.Networking.Packets.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Models
{
    public class Target
    {
        private int objectId;
        private string name;
        private Location position;

        public int ObjectId
        {
            get { return objectId; }
        }
        public string Name
        {
            get { return name; }
        }
        public Location Position
        {
            get { return position; }
        }

        public Target(int objectId, string name, Location position)
        {
            this.objectId = objectId;
            this.name = name;
            this.position = position;
        }

        public void UpdatePosition(Location position)
        {
            this.position = position;
        }

        public float DistanceTo(Target target)
        {
            return Position.DistanceTo(target.Position);
        }
    }
}
