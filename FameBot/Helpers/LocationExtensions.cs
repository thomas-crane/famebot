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
        /// <summary>
        /// Returns true if location2 is inside a circle with the specified radius.
        /// </summary>
        public static bool IntersectsRadius(this Location location, Location location2, float radius)
        {
            return location.DistanceTo(location2) <= radius;
        }
        
        /// <summary>
        /// Returns true if location2 is inside a square with the specified width.
        /// </summary>
        public static bool IntersectsRect(this Location location, Location location2, float width)
        {
            return location.X - width >= location2.X
                && location.X + width <= location2.X
                && location.Y + width <= location2.Y
                && location.Y - width >= location2.Y;
        }

        /// <summary>
        /// Returns the absolute difference in degrees between the angle between
        /// location and locationA and the angle between location and locationB.
        /// </summary>
        public static double GetAngleDifferenceDegrees(this Location location, Location locationA, Location locationB)
        {
            var angleA = Math.Atan2(locationA.Y - location.Y, locationA.X - location.X);
            var angleB = Math.Atan2(locationB.Y - location.Y, locationB.X - location.X);

            var diffRadians = angleA - angleB;
            return Math.Abs(diffRadians * (180 / Math.PI));
        }
    }
}
