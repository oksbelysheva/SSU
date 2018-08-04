using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class UnitSort
    {
        public static event Action Finished = () => Console.WriteLine("Sorting finished " + Thread.CurrentThread.ManagedThreadId.ToString());

        public static void SimpleSort(int[] array)
        {
            Sort.ArraySort(array, Sort.Ascending);
            Finished?.Invoke();
        }

        public static void SeparateThreadSort(int[] array)
        {
            Thread thread = new Thread(() => SimpleSort(array));
            thread.Start();
        }
    }
}
