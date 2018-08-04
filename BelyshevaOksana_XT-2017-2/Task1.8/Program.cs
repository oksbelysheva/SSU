using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._8
{
    public class Program
    {
        public static void FullMas(ref int[,,] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = r.Next(-100, 100);
                    }
                }
            }
        }

        public static void PrintAns(int[,,] arr, int[,,] negativeArr)
        {
            Console.WriteLine("Исходный массив:\t  Результат:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.Write("{0,5} ", arr[i, j, k]);
                    }

                    Console.Write("\t");
                    for (int k = 0; k < negativeArr.GetLength(2); k++)
                    {
                        Console.Write("{0,5} ", negativeArr[i, j, k]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("\n");
            }

            Console.Read();
        }

        public static void Main(string[] args)
        {
            int[,,] array3 = new int[6, 5, 3];
            FullMas(ref array3);
            int[,,] negativeArray = new int[array3.GetLength(0), array3.GetLength(1), array3.GetLength(2)];
            Array.Copy(array3, negativeArray, array3.Length);
            ReplacePositive(negativeArray);
            PrintAns(array3, negativeArray);
        }

        private static int[,,] ReplacePositive(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }

            return arr;
        }
    }
}
