using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Models
{
    public class Configuration
    {
        public float AutonexusThreshold { get; set; }
        public int TickCountThreshold { get; set; }
        public bool EscapeIfNoTargets { get; set; }
        public float TeleportDistanceThreshold { get; set; }
        public float FollowDistanceThreshold { get; set; }
        public bool AutoConnect { get; set; }

        public bool FindClustersNearCenter { get; set; }
        public float Epsilon { get; set; }
        public int MinPoints { get; set; }

        public string FlashProcessName { get; set; }

        public Configuration()
        {
        }
    }
}