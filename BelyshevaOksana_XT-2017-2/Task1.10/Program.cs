using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._10
{
    public class Program
    {
        public static void FullMas(ref int[,] mas)
        {
            Random r = new Random();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = r.Next(-10, 10);
                }
            }
        }

        public static void PrintAns(int[,] ans, int sum)
        {
            for (int i = 0; i < ans.GetLength(0); i++)
            {
                for (int j = 0; j < ans.GetLength(1); j++)
                {
                    Console.Write("{0, 4} ", ans[i, j]);
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("Сумма = {0}", sum);
            Console.Read();
        }

        public static void Main(string[] args)
        {
            int[,] arr2 = new int[5, 2];
            FullMas(ref arr2);
            int sum = EvenPosSum(arr2);
            PrintAns(arr2, sum);
        }

        private static int EvenPosSum(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            return sum;
        }
    }
}
