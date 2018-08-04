using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Если число имеет дробную часть, она отделяется запятой");
            Console.Write("Введите сторону треугольника a = ");
            double a = Double.Parse(Console.ReadLine());

            Console.Write("Введите сторону треугольника b = ");
            double b = Double.Parse(Console.ReadLine());

            Console.Write("Введите сторону треугольника c = ");
            double c = Double.Parse(Console.ReadLine());

            Triangle triangle = new Triangle(a, b, c);
            Console.WriteLine(triangle.toString());
        }
    }
}
