using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task21;

namespace Task27
{
    class Ring : Figure
    {
        private Circle inner;
        private Circle outer;

        public Point Center { get; set; }

        public Ring(double innerRadius, double outerRadius, Point center)
        {
            if (innerRadius >= outerRadius)
            {
                throw new ArgumentException("Ошибка: внутренний радиус должен быть меньше или равен внешнему радиусу");
            }
                this.Center = center;
                this.inner = new Circle(center, innerRadius);
                this.outer = new Circle(center, outerRadius);
        }

        public Ring(double innerRadius, double outerRadius, double x, double y) : this(innerRadius, outerRadius, new Point(x, y)) { }

        public override void Print()
        {
            Console.WriteLine("Кольцо:");
            Console.WriteLine("X: {0}", this.Center.X.ToString());
            Console.WriteLine("Y: = {0}", this.Center.Y.ToString());
            Console.WriteLine("Внешний радиус: {0}", this.outer.Radius.ToString());
            Console.WriteLine("Внутренний радиус: {0}", this.inner.Radius.ToString());
            Console.WriteLine();
        }

    }
}
