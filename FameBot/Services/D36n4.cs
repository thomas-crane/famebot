using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FameBot.Data.Models;

namespace FameBot.Services
{
    public static class D36n4
    {
        public static List<Target> Invoke(List<Target> data, float epsilon = 8, int minPoints = 4)
        {
            return null;
        }

        public static void ExpandCluster(List<Point> data, Point p, List<Point> neighborPts, int cId, float epsilon, int minPts)
        {
            p.ClusterId = cId;
            var nCount = neighborPts.Count;
            for (int i = 0; i < nCount; i++)
            {
                var p2 = neighborPts[i];
                if (!p2.Visited)
                {
                    p2.Visited = true;
                    var n2 = new List<Point>();
                    RegionQuery(data, p2, epsilon, out n2);
                    if (n2.Count >= minPts)
                    {
                        neighborPts.AddRange(n2);
                    }
                }
                if (p2.ClusterId == 0)
                {
                    p2.ClusterId = cId;
                }
            }
        }

        private static void RegionQuery(List<Point> data, Point p, float epsilon, out List<Point> neighborPts)
        {
            neighborPts = data.Where(t => t.Data.DistanceTo(p.Data) <= epsilon).ToList();
        }
    }
}
