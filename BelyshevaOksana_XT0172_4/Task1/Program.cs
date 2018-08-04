using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] a = { 1, 100, -4, 5, 13, 13, -13, 896, -1000 };
            Sort.ArraySort(a, Sort.Ascending);
            ShowArray(a);

            Sort.ArraySort(a, Sort.Descending);
            ShowArray(a);

            string[] stringTest = { "b", "bcd", "aa", "11", "2", "aaa", "bbb", "acd" };
            Sort.ArraySort(stringTest, Sort.Ascending);
            ShowArray(stringTest);

            Sort.ArraySort(stringTest, Sort.Descending);
            ShowArray(stringTest);
        }

        private static void ShowArray<T>(T[] a)
        {
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
