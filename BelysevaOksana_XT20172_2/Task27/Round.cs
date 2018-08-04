using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task21;

namespace Task27
{
    public class Round : Figure
    {
        private double radius;
        Point center;

        public Round(Point center, double radius)
        {
            this.radius = radius;
            this.center = center;
        }

        public Round(double x, double y, double radius) : this(new Point(x, y), radius) { }

        public override void Print()
        {
            Console.WriteLine("Круг:");
            Console.WriteLine("x: {0}", this.center.X.ToString());
            Console.WriteLine("y: {0}", this.center.Y.ToString());
            Console.WriteLine("Радиус: {0}", this.radius.ToString());
            Console.WriteLine();
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("Ошибка: неправильное значение для радиуса");
                this.radius = value;
            }
        }

        public Point Center
        {
            get
            {
                return this.center;
            }
            set
            {
                this.center = value;
            }
        }


    }
}
