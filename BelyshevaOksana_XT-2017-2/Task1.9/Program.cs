using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._9
{
    public class Program
    {
        public static void FullMas(int[] mas)
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                mas[i] = r.Next(-100, 100);
            }
        }

        public static void PrintAns(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine(sum);
            Console.Read();
        }

        public static void Main(string[] args)
        {
            int[] array1 = new int[5];
            FullMas(array1);
            PrintAns(array1);
        }
    }
}
