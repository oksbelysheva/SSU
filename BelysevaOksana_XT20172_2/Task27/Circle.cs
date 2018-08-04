using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task21;

namespace Task27
{
    class Circle : Round
    {
        public Circle(double x, double y, double radius) : base(x, y, radius)
        {
            this.Center = new Task21.Point(x, y);
            this.Radius = radius;
        }

        public Circle(Point center, double radius) : base(center.X, center.Y, radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public override void Print()
        {
            Console.WriteLine("Окружность:");
            Console.WriteLine("x: {0}", this.Center.X.ToString());
            Console.WriteLine("y: {0}", this.Center.Y.ToString());
            Console.WriteLine("Радиус: {0}", this.Radius.ToString());
            Console.WriteLine();
        }
    }
}
