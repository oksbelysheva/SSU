using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task21
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Point p = obj as Point;
            if ((object)p == null)
            {
                return false;
            }

            return (this.X == p.X) && (this.Y == p.Y);
        }

        public bool Equals(Point p)
        {
            if ((object)p == null)
            {
                return false;
            }

            return (this.X == p.X) && (this.Y == p.Y);
        }

        public override int GetHashCode() => (int)this.X ^ (int)this.Y;
    }
}
