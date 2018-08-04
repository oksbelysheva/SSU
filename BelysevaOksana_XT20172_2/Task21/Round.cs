using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task21
{
    public class Round
    {
        private Point coordinateCenter;
        private double radius;

        public Round(Point coordinateCenter, double radius)
        {
            try
            {
                if (radius <= 0)
                {
                    throw new Exception();
                }
                else
                {
                    this.radius = radius;
                }

                this.coordinateCenter = coordinateCenter;
            }
            catch
            {
                Console.WriteLine("Некорректные данные для радиуса");
            }
        }

        public Round(double x, double y, double radius) : this(new Point(x, y), radius)
        {
        }

        public double LengthRound
        {
            get
            {
                return 2 * Math.PI * this.radius;
            }
        }

        public double AreaCircle
        {
            get
            {
                return Math.PI * Math.Pow(this.radius, 2);
            }
        }

        public bool Correct
        {
            get
            {
                return (this.coordinateCenter != null);
            }
        }

        public override string ToString()
        {
            string res = string.Empty;
            if (this.Correct)
            {
                res = string.Format("Длина окружности = {0}{2}Площадь круга = {1}", this.LengthRound, this.AreaCircle, Environment.NewLine);
            }

            return res;
        }
    }
}
