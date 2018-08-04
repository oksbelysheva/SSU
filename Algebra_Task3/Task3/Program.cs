using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int[,]> matrixs = ReadMatrix();
            BuildSemigroup(matrixs);
        }

        private static List<int[,]> ReadMatrix()
        {
            StreamReader reader = new StreamReader("input.txt");
            int countMatrix = int.Parse(reader.ReadLine());
            int sizeOneMatrix = int.Parse(reader.ReadLine());
            List<int[,]> matrixs = new List<int[,]>();

            for (int k = 0; k < countMatrix; k++)
            {
                int[,] oneMatrix = new int[sizeOneMatrix, sizeOneMatrix];
                for (int i = 0; i < sizeOneMatrix; i++)
                {
                    string row = reader.ReadLine();
                    string[] elements = row.Split(' ');
                    for (int j = 0; j < sizeOneMatrix; j++)
                    {
                        oneMatrix[i, j] = int.Parse(elements[j]);
                    }
                }

                matrixs.Add(oneMatrix);
            }

            reader.Close();
            return matrixs;
        }

        private static int[,] MultiplicationMatrix(int[,] a, int[,] b)
        {
            int length = a.GetLength(0);
            int[,] result = new int[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    for (int k = 0; k < length; k++)
                    {
                        if (a[i, k] == 1 && b[k, j] == 1)
                        {
                            result[i, j] = 1;
                        }
                    }
                }
            }

            return result;
        }

        private static bool IsEquals(int[,] a, int[,] b)
        {
            int length = a.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static int[,] BuildCayley(Dictionary<int, int[,]> a)
        {
            int[,] tableCayley = new int[a.Count, a.Count];
            for (int i = 0; i < tableCayley.GetLength(0); i++)
            {
                for (int j = 0; j < tableCayley.GetLength(1); j++)
                {
                    int[,] b = MultiplicationMatrix(a[i], a[j]);
                    bool newElement = true;
                    foreach (var item in a)
                    {
                        if (IsEquals(item.Value, b))
                        {
                            newElement = false;
                            tableCayley[i, j] = item.Key;
                            break;
                        }
                    }

                    if (newElement)
                    {
                        a.Add(a.Count, b);
                        tableCayley[i, j] = a.Count - 1;
                    }
                }
            }

            return tableCayley;
        }

        private static void BuildSemigroup(List<int[,]> a)
        {
            Dictionary<int, int[,]> allElements = new Dictionary<int, int[,]>();
            for (int i = 0; i < a.Count; i++)
            {
                allElements.Add(i, a[i]);
            }

            int[,] tableSemigroup = null;
            int countMatrix = allElements.Count;
            do
            {
                countMatrix = allElements.Count;
                tableSemigroup = BuildCayley(allElements);
            }
            while (countMatrix != allElements.Count);

            Console.WriteLine("Таблица Кэли:");
            Console.Write("  ");
            for (int i = 0; i < tableSemigroup.GetLength(0); i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < tableSemigroup.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < tableSemigroup.GetLength(1); j++)
                {
                    Console.Write(tableSemigroup[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            int[] keys = allElements.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                Console.WriteLine(keys[i] + ":");
                for (int k = 0; k < allElements[keys[i]].GetLength(0); k++)
                {
                    for (int j = 0; j < allElements[keys[i]].GetLength(1); j++)
                    {
                        Console.Write(allElements[keys[i]][k, j] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
