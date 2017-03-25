using Lib_K_Relay.Networking.Packets.DataObjects;

namespace FameBot.Data.Models
{
    public class Rock
    {
        public Rock(int objectId, Location location)
        {
            ObjectId = objectId;
            Location = location;
        }

        public int ObjectId { get; set; }
        public Location Location { get; set; }
    }
}