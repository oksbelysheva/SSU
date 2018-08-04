using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._7
{
    public class Program
    {
        public static void FullArray(ref int[] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(100);
            }
        }

        public static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write("{0,4} ", item);
            }

            Console.WriteLine();
        }

        public static void DoQuickSort(ref int[] arr, int first, int last)
        {
            int pos = ((last - first) / 2) + first;
            int p = arr[pos];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last)
                {
                    ++i;
                }

                while (arr[j] > p && j >= first)
                {
                    --j;
                }

                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i;
                    --j;
                }
            }

            if (j > first)
            {
                DoQuickSort(ref arr, first, j);
            }

            if (i < last)
            {
                DoQuickSort(ref arr, i, last);
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[10];
            FullArray(ref arr);
            Console.WriteLine("Исходный массив: ");
            PrintArray(arr);
            DoQuickSort(ref arr, 0, arr.Length - 1);
            Console.WriteLine("Отсортированный массив: ");
            PrintArray(arr);
            Console.WriteLine("Минимальное значение = {0}", arr[0]);
            Console.WriteLine("Максимальное значение = {0}", arr[arr.Length - 1]);
        }
    }
}
