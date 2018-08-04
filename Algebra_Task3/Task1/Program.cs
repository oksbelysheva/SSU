using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<char, int> elements = ReadElements();
            char[,] operations = ReadOperation();
            int length = elements.Count;

            char[] allElements = new char[length];

            int pos = 0;
            foreach (var item in elements)
            {
                allElements[pos++] = item.Key;
            }

            Console.Write("  ");
            for (int i = 0; i < length; i++)
            {
                Console.Write(allElements[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                Console.Write(allElements[i] + " ");
                for (int j = 0; j < length; j++)
                {
                    Console.Write(operations[i, j] + " ");
                }

                Console.WriteLine();
            }

            if (IsAssociative(elements, operations))
            {
                Console.WriteLine("Операция является ассоциативной");
            }
            else
            {
                Console.WriteLine("Операция не является ассоциативной");
            }

            if (IsCommutative(operations))
            {
                Console.WriteLine("Операция является коммутативной");
            }
            else
            {
                Console.WriteLine("Операция не является коммутативной");
            }
        }

        private static Dictionary<char, int> ReadElements()
        {
            StreamReader streamReader = new StreamReader("input.txt");
            string str = streamReader.ReadLine();
            string[] splitStr = str.Split(' ');
            Dictionary<char, int> elements = new Dictionary<char, int>();
            for (int i = 0; i < splitStr.Length; i++)
            {
                elements.Add(char.Parse(splitStr[i]), i);
            }

            streamReader.Close();

            return elements;
        }

        private static char[,] ReadOperation()
        {
            StreamReader reader = new StreamReader("input.txt");
            string element = reader.ReadLine();
            string[] countElements = element.Split(' ');
            int length = countElements.Length;

            char[,] tableBinaryOperations = new char[length, length];
            for (int i = 0; i < length; i++)
            {
                string row = reader.ReadLine();
                string[] splitRow = row.Split(' ');
                for (int j = 0; j < length; j++)
                {
                    tableBinaryOperations[i, j] = char.Parse(splitRow[j]);
                }
            }

            reader.Close();

            return tableBinaryOperations;
        }

        private static bool IsAssociative(Dictionary<char, int> elements, char[,] table)
        {
            int length = table.GetLength(0);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    for (int z = 0; z < length; z++)
                    {
                        if (table[elements[table[x, y]], z] != table[x, elements[table[y, z]]])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static bool IsCommutative(char[,] table)
        {
            int length = table.GetLength(0);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if (table[x, y] != table[y, x])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
