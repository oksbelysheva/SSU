using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfRepresentetives
{
    class Hasse
    {
        public int[,] hasseMatrix;
        public Hasse()
        {
            
            Relations relations = new Relations();

            Console.WriteLine("Матрица смежности:");
            for (int i = 0; i < relations.size; i++)
            {
                for (int j = 0; j < relations.size; j++)
                {
                    Console.Write(relations.matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            hasseMatrix = new int[relations.size, relations.size];
            for (int i = 0; i < relations.size; i++)
            {
                for (int j = 0; j < relations.size; j++)
                {
                    if (relations.matrix[i, j] == 1)
                    {
                        hasseMatrix[i, j] = 1;
                        for (int k = 0; k < relations.size; k++)
                        {
                            if (relations.matrix[i, k] == 1 && relations.matrix[k, j] == 1 && k != i && k != j)
                            {
                                hasseMatrix[i, j] = 0;
                                break;
                            }
                        }
                    }
                    else
                    {
                        hasseMatrix[i, j] = 0;
                    }
                }
            }

            List<int> source = FindSource(hasseMatrix);

            Console.WriteLine();
            Console.WriteLine("Диаграмма Хассе:");
            for (int i = 0; i < relations.size; i++)
            {
                for (int j = 0; j < relations.size; j++)
                {
                    Console.Write(hasseMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            List<int> vertex = new List<int>(source);
            List<HashSet<int>> levels = new List<HashSet<int>>();
            while (vertex.Count != 0)
            {
                levels.Add(new HashSet<int>(vertex));
                int countVertex = vertex.Count();
                for (int k = countVertex; k > 0; k--)
                {
                    for (int i = 0; i < hasseMatrix.GetLength(0); i++)
                    {
                        if (i != vertex[0] && hasseMatrix[vertex[0], i] == 1)
                        {
                                vertex.Add(i);
                        }
                    }
                    vertex.Remove(vertex[0]);
                } 
            }

            for (int i = levels.Count-1; i > 0; i--)
            {
                for (int j = 0; j < levels[i].Count; j++)
                {
                    for (int k = i-1; k > 0; k--)
                    {
                        levels[k].Remove(levels[i].ElementAt(j));
                    }
                }
            }
            for (int i = levels.Count-1; i >= 0; i--)
            {
                Console.Write("уровень {0}: ", i);
                for (int j = 0; j < levels[i].Count; j++)
                {
                    Console.Write(levels[i].ElementAt(j)+" ");
                }
                Console.WriteLine();
            }

            if (source.Count == 1)
            {
                Console.Write("Наименьший элемент: " + source[0]);
            }
            else
            {
                Console.Write("Минимальные элменты: ");
                foreach (var item in source)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();

            if (levels[levels.Count-1].Count == 1)
            {
                Console.WriteLine("Наибольший элемент: " + levels[levels.Count - 1].ElementAt(0));
            }
            else
            {
                Console.Write("Максимальные элменты: ");
                foreach (var item in levels[levels.Count - 1])
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

        }

        private List<int> FindSource(int[,] matrix)
        {
            List<int> source = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j,i];
                }
                if (sum == 1)
                    source.Add(i);
            }
            return source;
        }
    }
}

