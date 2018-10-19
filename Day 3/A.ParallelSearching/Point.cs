using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.ParallelSearching
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double GetDistanceFrom (Point p)
        {
            double dx, dy;
            dx = p.X - X;
            dy = p.Y - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
