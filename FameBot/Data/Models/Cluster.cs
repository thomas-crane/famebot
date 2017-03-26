using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameBot.Data.Models
{
    public class Cluster
    {
        public int Id { get; set; }
        public List<ClusterPoint> Points { get; set; }
        public float Epsilon { get; set; }
        public int Count
        {
            get { return Points?.Count ?? 0; }
        }

        public Cluster()
        {
            Points = new List<ClusterPoint>();
            Epsilon = 8f;
        }

        public void Add(ClusterPoint p)
        {
            Points.Add(p);
        }

        public void AddRange(List<ClusterPoint> p)
        {
            Points.AddRange(p);
        }

        public void AddRange(Cluster c)
        {
            Points.AddRange(c.Points);
        }

        public bool Contains(ClusterPoint p)
        {
            return Points.Contains(p);
        }
    }
}
