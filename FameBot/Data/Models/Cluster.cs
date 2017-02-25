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
        public List<Point> Points { get; set; }
        public float Epsilon { get; set; }
        public int Count
        {
            get { return Points?.Count ?? 0; }
        }

        public Cluster()
        {
            Points = new List<Point>();
            Epsilon = 8f;
        }

        public void Add(Point p)
        {
            Points.Add(p);
        }

        public void AddRange(List<Point> p)
        {
            Points.AddRange(p);
        }

        public void AddRange(Cluster c)
        {
            Points.AddRange(c.Points);
        }

        public bool Contains(Point p)
        {
            return Points.Contains(p);
        }
    }
}
