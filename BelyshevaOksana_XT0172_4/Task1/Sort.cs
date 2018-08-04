using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Sort
    {
        public static int Ascending<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b);
        }

        public static int Descending<T>(T a, T b) where T : IComparable
        {
            return b.CompareTo(a);
        }

        public static int Ascending(int a, int b)
        {
            return a - b;
        }

        public static int Descending(int a, int b)
        {
            return b - a;
        }

        public static int Ascending(string a, string b)
        {
            if (a.Length < b.Length)
            {
                return -1;
            }

            if (a.Length > b.Length)
            {
                return 1;
            }

            return a.CompareTo(b);
        }

        public static int Descending(string a, string b)
        {
            if (a.Length < b.Length)
            {
                return 1;
            }

            if (a.Length > b.Length)
            {
                return -1;
            }

            return b.CompareTo(a);
        }

        public static void QuickSort<T>(T[] array, int left, int right, Func<T, T, int> compare)
        {
            int i = left, j = right;
            T temp;

            T pivot = array[left + ((right - left) / 2)];

            while (i <= j)
            {
                while (compare?.Invoke(array[i], pivot) < 0)
                {
                    i++;
                }

                while (compare?.Invoke(array[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(array, left, j, compare);
            }

            if (i < right)
            {
                QuickSort(array, i, right, compare);
            }
        }

        public static void ArraySort<T>(T[] array, Func<T, T, int> compare)
        {
            QuickSort(array, 0, array.Length - 1, compare);
        }
    }
}
