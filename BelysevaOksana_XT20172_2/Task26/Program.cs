using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task21;

namespace Task26
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Если число имеет дробную часть, она отделяется запятой");
            Console.Write("Введите координату центра x: ");
            double x = Double.Parse(Console.ReadLine());

            Console.Write("Введите координату центра y: ");
            double y = Double.Parse(Console.ReadLine());

            Console.Write("Введите внешний радиус: ");
            double outerRadius = Double.Parse(Console.ReadLine());

            Console.Write("Введите внутренний радиус: ");
            double innerRadius = Double.Parse(Console.ReadLine());

            Point center = new Point(x, y);
            Ring ring = new Ring(center, innerRadius, outerRadius);
            Console.WriteLine(ring.ToString());
        }
    }
}
