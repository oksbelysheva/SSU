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
            int[] b = { 434, 43, -3254, 2, 34, 1, 78, 3, -243, 543 };
            UnitSort.SeparateThreadSort(b);

            int[] c = { 543, 324, 21, -43, 214, -243 };
            UnitSort.SeparateThreadSort(c);

            int[] a = { 434, 43, -3254, 2, 34, 1, 78, 3, -243 };
            UnitSort.SimpleSort(a);
        }
    }
}
