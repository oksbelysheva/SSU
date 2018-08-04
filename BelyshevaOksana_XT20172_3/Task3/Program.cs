using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // condition 1
            DynamicArray<string> dynamicArray = new DynamicArray<string>();
            Console.WriteLine($"при создании конструктора без параметров Capacity = {dynamicArray.Capacity}");
            Console.WriteLine($"при создании конструктора без параметров Length = {dynamicArray.Length}");
            Console.WriteLine();

            // condition 2
            dynamicArray = new DynamicArray<string>(5);
            Console.WriteLine($"при создании конструктора с одним целочисленным параметром Capacity(5) = {dynamicArray.Capacity}");
            Console.WriteLine($"при создании конструктора с одним целочисленным параметром Length = {dynamicArray.Length}");
            Console.WriteLine();

            // condition 3
            List<string> list = new List<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");
            list.Add("E");
            list.Add("F");
            dynamicArray = new DynamicArray<string>(list);
            Console.WriteLine($"при создании конструктора с коллекцией размером {list.Count} Capacity = {dynamicArray.Capacity}");
            Console.WriteLine($"при создании конструктора с коллекцией размером {list.Count} Length = {dynamicArray.Length}");
            ShowDynamicArray(dynamicArray);
            Console.WriteLine();

            // condition 4
            dynamicArray.Add("G");
            Console.WriteLine($"при добавления элемента в конец Capacity = {dynamicArray.Capacity}");
            Console.WriteLine($"при добавления элемента в конец Length = {dynamicArray.Length}");
            ShowDynamicArray(dynamicArray);
            Console.WriteLine();

            // condition 5
            list = new List<string>();
            list.Add("H");
            list.Add("I");
            list.Add("J");
            list.Add("K");
            list.Add("L");
            list.Add("M");
            dynamicArray.AddRange(list);
            Console.WriteLine($"при добавления коллекции размером {list.Count} в конец Capacity = {dynamicArray.Capacity}");
            Console.WriteLine($"при добавления коллекции размером {list.Count} в конец Length = {dynamicArray.Length}");
            ShowDynamicArray(dynamicArray);
            Console.WriteLine();

            // condiotion 6
            Console.WriteLine("попытка удаления G первый раз {0}", dynamicArray.Remove("G"));
            Console.WriteLine($"при удалении элемента G Capacity = {dynamicArray.Capacity}");
            Console.WriteLine($"при удалении элемента G Length = {dynamicArray.Length}");
            ShowDynamicArray(dynamicArray);
            Console.WriteLine("попытка удаления G второй раз {0}", dynamicArray.Remove("G"));
            Console.WriteLine();

            // condition 7
            dynamicArray.Insert(7, "G");
            Console.WriteLine($"при добавления элемента на позицию 7 Capacity = {dynamicArray.Capacity}");
            Console.WriteLine($"при добавления элемента на позицию 7 Length = {dynamicArray.Length}");
            ShowDynamicArray(dynamicArray);
            // ArgumentOutOfRangeException
            // dynamicArray.Insert(14,"G");
            Console.WriteLine();

            // condition 11
            Console.WriteLine($"Вывод нулевого элемента: {dynamicArray[0]}");

            // condition 1
            Console.WriteLine($"Вывод -1 элемента: {dynamicArray[-1]}");

            // condition 2
            dynamicArray.Capacity = 10;
            Console.WriteLine($"при изменении Capacity на 10 Capacity = {dynamicArray.Capacity}");
            Console.WriteLine($"при изменении Capacity на 10 Length = {dynamicArray.Length}");
            ShowDynamicArray(dynamicArray);
            Console.WriteLine();

            // condition 3
            Console.WriteLine("Создание Clone");
            DynamicArray<string> cloneDynamicArray = (DynamicArray<string>)dynamicArray.Clone();
            Console.WriteLine($"Capacity Clone = {cloneDynamicArray.Capacity}");
            Console.WriteLine($"Length Clone = {cloneDynamicArray.Length}");
            ShowDynamicArray(cloneDynamicArray);
            Console.WriteLine();

            // condition 4
            string[] toArray = dynamicArray.ToArray();
            Console.WriteLine("ToArray:");
            foreach (var item in toArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine();

            CycledDynamicArray<int> cycledDynamic = new CycledDynamicArray<int>() { 1, 2, 3, 4 };
            Console.WriteLine("CycledDynamicArray:");
            int count = 10;
            foreach (var item in cycledDynamic)
            {
                Console.Write(item + " ");
                count--;
                if (count == 0)
                {
                    break;
                }
            }
        }

        private static void ShowDynamicArray<T>(DynamicArray<T> b) where T : IComparable
        {
            // condition 10
            Console.WriteLine("DynamicArray:");
            foreach (var item in b)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
