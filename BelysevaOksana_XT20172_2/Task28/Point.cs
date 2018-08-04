using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task28
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Field f)
        {
            Random random = new Random();
            this.x = random.Next(Field.Width);
            this.y = random.Next(Field.Height);
        }

        public int x { get; set; }

        public int y { get; set; }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Point p = obj as Point;
            if ((System.Object)p == null)
            {
                return false;
            }

            return (x == p.x) && (y == p.y);
        }

        public bool Equals(Point p)
        {
            if ((object)p == null)
            {
                return false;
            }

            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode() => (int)x ^ (int)y;
    }
}
