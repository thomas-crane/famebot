using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_K_Relay.Networking.Packets.DataObjects;

namespace FameBot.Helpers
{
    public static class LocationExtensions
    {
        public static bool IntersectsRadius(this Location location, Location location2, float radius)
        {
            return location.DistanceTo(location2) <= radius;
        }
        public static bool IntersectsRect(this Location location, Location location2, float width)
        {
            return location.X - width >= location2.X
                && location.X + width <= location2.X
                && location.Y + width <= location2.Y
                && location.Y - width >= location2.Y;
        }
    }
}
