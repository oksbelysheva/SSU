using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Если число имеет дробную часть, она отделяется запятой");
            Console.Write("Введите координату центра x: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите координату центра y: ");
            double y = double.Parse(Console.ReadLine());

            Console.Write("Введите радиус: ");
            double radius = double.Parse(Console.ReadLine());

            Point center = new Point(x, y);
            Round round = new Round(center, radius);
            Console.WriteLine(round.ToString());
        }
    }
}
