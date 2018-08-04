using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task21;

namespace Task27
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Point PointLeftDown { get; set; }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("Ошибка: ширина прямоугольника должна быть положительным числом");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("Ошибка: высота прямоугольника должна быть положительным числом");
                }

                this.height = value;
            }
        }

        public Rectangle(double width, double height, Point pointLeftDown)
        {
            this.PointLeftDown = pointLeftDown;
            this.Width = width;
            this.Height = height;
        }

        public Rectangle(double width, double height, double x, double y):this(width, height, new Point(x,y))
        {
        }

        public override void Print()
        {
            Console.WriteLine("Прямоугольник:");
            Console.WriteLine("x: {0}", this.PointLeftDown.X.ToString());
            Console.WriteLine("Координата Y = {0}", this.PointLeftDown.Y.ToString());
            Console.WriteLine("Ширина прямоугольника: {0}", this.Width.ToString());
            Console.WriteLine("Высота прямоугольника: {0}", this.Height.ToString());
            Console.WriteLine();
        }
    }
}
