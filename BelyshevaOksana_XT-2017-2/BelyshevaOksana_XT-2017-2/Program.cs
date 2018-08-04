using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a, b;
            Console.Write("Введите сторону прямоугольника a := ");
            bool resultA = int.TryParse(Console.ReadLine(), out a);
            if (!resultA)
            {
                a = -1;
            }

            Console.Write("Введите сторону прямоугольника b := ");
            bool resultB = int.TryParse(Console.ReadLine(), out b);
            if (!resultB)
            {
                b = -1;
            }

            SquareRectangle(a, b);
        }

        private static void SquareRectangle(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                Console.WriteLine("Ошибка: сторона прямоугольника должна являться положительным числом");
            }
            else
            {
                Console.WriteLine(a * b);
            }
        }
    }
}
