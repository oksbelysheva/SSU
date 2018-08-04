using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> allElements = ReadElements();
            Dictionary<string, string> rules = ReadRules();
            string[,] tableSemigroup = BuildSemigroup(allElements, rules);
            Console.Write("S = { ");
            string[] elementsSemigroup = allElements.Values.ToArray();
            foreach (var item in elementsSemigroup)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(" }");

            Console.WriteLine();

            Console.WriteLine("Таблица Кэли:");
            Console.Write("\t");
            foreach (var item in elementsSemigroup)
            {
                Console.Write(item + "\t");
            }

            Console.WriteLine();
            int length = tableSemigroup.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                Console.Write(elementsSemigroup[i] + "\t");
                for (int j = 0; j < length; j++)
                {
                    Console.Write(tableSemigroup[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        private static Dictionary<int, string> ReadElements()
        {
            StreamReader reader = new StreamReader("input.txt");
            string str = reader.ReadLine();
            string[] splitStr = str.Split(' ');
            int length = splitStr.Length;
            Dictionary<int, string> elements = new Dictionary<int, string>();
            for (int i = 0; i < length; i++)
            {
                elements.Add(i, splitStr[i]);
            }

            reader.Close();
            return elements;
        }

        private static Dictionary<string, string> ReadRules()
        {
            StreamReader reader = new StreamReader("input.txt");
            string element = reader.ReadLine();
            string[] elements = element.Split(' ');
            string input = "S = <";
            for (int i = 0; i < elements.Length - 1; i++)
            {
                input += elements[i] + ", ";
            }

            input += elements[elements.Length - 1] + " : ";
            int n = int.Parse(reader.ReadLine());

            Dictionary<string, string> rules = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string rule = reader.ReadLine();
                input += rule;
                if (i < n - 1)
                {
                    input += ", ";
                }

                string[] partsEquals = rule.Split('=');
                rules.Add(partsEquals[0], partsEquals[1]);
            }

            input += ">";
            Console.WriteLine(input);

            return rules;
        }

        private static string[,] BuildTable(Dictionary<int, string> elements, Dictionary<string, string> rules)
        {
            int length = elements.Count;
            string[,] table = new string[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    string element = UseRulesAtElement(elements[i] + elements[j], rules);
                    table[i, j] = element;
                    if (!elements.ContainsValue(element))
                    {
                        elements.Add(elements.Count, element);
                    }
                }
            }

            return table;
        }

        private static string UseRulesAtElement(string element, Dictionary<string, string> rules)
        {
            string[] leftEquals = rules.Keys.ToArray();
            int length = leftEquals.Length;
            bool change = false;
            do
            {
                change = false;
                for (int i = 0; i < length; i++)
                {
                    if (element.Contains(leftEquals[i]))
                    {
                        change = true;
                        string rightEquals = rules[leftEquals[i]];
                        element = element.Replace(leftEquals[i], rightEquals);
                    }
                }
            }
            while (change);

            return element;
        }

        private static string[,] BuildSemigroup(Dictionary<int, string> elements, Dictionary<string, string> rules)
        {
            bool newEllement = false;
            string[,] tableSemigroup = null;
            do
            {
                newEllement = false;
                int sizeElements = elements.Count;
                string[,] table = BuildTable(elements, rules);
                if (sizeElements != elements.Count)
                {
                    newEllement = true;
                }
                else
                {
                    tableSemigroup = table;
                }
            }
            while (newEllement);

            return tableSemigroup;
        }
    }
}
