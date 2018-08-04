using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int foldThreeAndFive = ArithmeticProgressionBelow1000(3, 3) + ArithmeticProgressionBelow1000(5, 5) - ArithmeticProgressionBelow1000(15, 15);
            Console.WriteLine("Сумма чисел кратных трем или пяти = ", foldThreeAndFive);
        }

        public static int ArithmeticProgressionBelow1000(int a1, int d)
        {
            int n = 1000 / a1;
            int an = a1 + (d * (n - 1));
            return (a1 + an) * n / 2;
        }
    }
}
