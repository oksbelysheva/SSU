using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22
{
    public class Triangle
    {
        private double a, b, c;

        public Triangle(double a, double b, double c)
        {
            try
            {
                if (a <= 0 || b <= 0 || c <= 0 || (a >= b + c) || (b >= a + c) || (c >= a + b))
                {
                    throw new Exception();
                }
                this.a = a;
                this.b = b;
                this.c = c;
            }
            catch
            {
                Console.WriteLine("Ошибка: введены некорректные данные для сторон треугольника");
            }
        }

        public double Perimeter
        {
            get
            {
                return this.a + this.b + this.c;
            }
        }

        public double Area
        {
            get
            {
                double p = this.Perimeter/2;
                return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            }
        }

        public bool Correct
        {
            get
            {
                return (a!=0);
            }
        }

        public string toString()
        {
            String res = "";
            if (this.Correct)
            {
                res = String.Format("Периметр треугольника = {0}{2}Площадь треугольника = {1}", this.Perimeter, this.Area, Environment.NewLine);
            }
            return res;
        }
    }
}
