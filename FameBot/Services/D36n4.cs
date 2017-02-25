using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FameBot.Data.Models;
using Lib_K_Relay.Networking.Packets.DataObjects;

namespace FameBot.Services
{
    public static class D36n4
    {
        public static List<Target> Invoke(List<Target> data, float epsilon = 8, int minPoints = 4, bool findNearCenter = true)
        {
            var C = 0;
            var points = new List<Point>();
            foreach (Target t in data)
            {
                points.Add(new Point(t));
            }

            var pCount = points.Count;
            for (int i = 0; i < pCount; i++)
            {
                var p = points[i];
                if (p.Visited)
                    continue;
                p.Visited = true;
                var neighborPts = new List<Point>();
                RegionQuery(points, p, epsilon, out neighborPts);
                if (neighborPts.Count < minPoints)
                {
                    p.ClusterId = -1;
                }
                else
                {
                    C++;
                    ExpandCluster(points, p, neighborPts, C, epsilon, minPoints);
                }
            }
            var clusters = points.Where(p => p.ClusterId > 0).GroupBy(p => p.ClusterId).Select(t => t.Select(x => x.Data)?.ToList()) ?? null;

            if (clusters == null)
                return null;

            if(findNearCenter)
            {
                clusters = clusters.Where(c => c.Average(p => p.Position.DistanceTo(new Location(1000, 1000))) < 600);
                clusters = clusters.OrderBy(c => c.Average(p => p.Position.DistanceTo(new Location(1000, 1000))));
            }
            return clusters.Where(c => c.Count == clusters.Max(x => x.Count)).FirstOrDefault();
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
