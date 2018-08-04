using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class SeekPositiveElement
    {
        public static void SimpleSeekPositiveElement(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    count++;
                }
            }
        }

        public static bool IsPositive(int element)
        {
            return element > 0;
        }

        public static void DelegateSeekPositiveElement(int[] array, Predicate<int> positive)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (positive(array[i]))
                {
                    count++;
                }
            }
        }

        public static void LINQSeekPositiveElement(int[] array)
        {
            int count = array.Count((x) => (x > 0));
        }
    }
}
