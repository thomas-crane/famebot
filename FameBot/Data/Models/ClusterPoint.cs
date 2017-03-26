using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Models
{
    public class ClusterPoint
    {
        public int ClusterId { get; set; }
        public bool Noisy { get; set; }
        public bool Visited { get; set; }
        public Target Data { get; set; }

        public ClusterPoint(Target t)
        {
            this.Noisy = false;
            this.Visited = false;
            this.Data = t;
        }

        public static List<ClusterPoint> FromListOfTargets(List<Target> targets)
        {
            List<ClusterPoint> pointList = new List<ClusterPoint>();
            foreach(Target t in targets)
            {
                pointList.Add(new ClusterPoint(t));
            }
            return pointList;
        }
    }
}
