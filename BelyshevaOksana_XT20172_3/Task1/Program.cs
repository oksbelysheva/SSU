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
            Console.WriteLine("Введите N:");
            int n = int.Parse(Console.ReadLine());

            LinkedList<int> people = new LinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                people.AddLast(i);
            }

            ShowCurrentState(people);
            bool deleted = false;
            while (people.Count != 1)
            {
                if (!deleted)
                {
                    LinkedListNode<int> first = people.First;
                    people.RemoveFirst();
                    people.AddLast(first);
                    ShowCurrentState(people);
                }
                else
                {
                    people.RemoveFirst();
                    ShowCurrentState(people);
                }

                deleted = !deleted;
            }
        }

        private static void ShowCurrentState(LinkedList<int> people)
        {
            foreach (var item in people)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
