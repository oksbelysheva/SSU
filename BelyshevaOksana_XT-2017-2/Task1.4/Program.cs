using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n;
            Console.Write("Введите N: ");
            n = int.Parse(Console.ReadLine());

            for (int j = 0; j <= n; j++)
            {
                PaintXMasTree(n, j);
            }
        }

        private static void PaintXMasTree(int n, int j)
        {
            for (int i = 0; i < j; i++)
            {
                Console.Write(new string(' ', n - i - 1));
                Console.WriteLine(new string('*', (2 * i) + 1));
            }
        }
    }
}
