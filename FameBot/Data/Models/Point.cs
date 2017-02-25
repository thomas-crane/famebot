using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Models
{
    public class Point
    {
        public int ClusterId { get; set; }
        public bool Noisy { get; set; }
        public bool Visited { get; set; }
        public Target Data { get; set; }

        public Point(Target t)
        {
            this.Noisy = false;
            this.Visited = false;
            this.Data = t;
        }

        public static List<Point> FromListOfTargets(List<Target> targets)
        {
            List<Point> pointList = new List<Point>();
            foreach(Target t in targets)
            {
                pointList.Add(new Point(t));
            }
            return pointList;
        }
    }
}
