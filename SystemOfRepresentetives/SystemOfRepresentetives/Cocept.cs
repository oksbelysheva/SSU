using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfRepresentetives
{
    class Cocept
    {
        public Cocept()
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

            HashSet<List<int>> crossing = new HashSet<List<int>>();

            for (int i = 0; i < relations.size; i++)
            {
                List<int> tempCrossing = new List<int>();
                for (int j = 0; j < relations.size; j++)
                {
                    if (relations.matrix[j, i] == 1)
                    {
                        tempCrossing.Add(j + 1);
                    }
                }
                crossing.Add(tempCrossing);
            }

            while (true)
            {
                int flag = crossing.Count();

                for (int i = 0; i < crossing.Count; i++)
                {
                    for (int j = i+1; j < crossing.Count; j++)
                    {
                        List<int> tempCrossing = new List<int>();
                        foreach (var item in crossing.ElementAt(i))
                        {
                            if (crossing.ElementAt(j).Contains(item))
                            {
                                tempCrossing.Add(item);
                            }
                        }
                        bool flag2 = true;
                        for (int l = 0; l < crossing.Count; l++)
                        {
                            if (tempCrossing.Count == crossing.ElementAt(l).Count)
                            {
                                for (int t = 0; t < crossing.ElementAt(l).Count; t++)
                                {
                                    if (!(crossing.ElementAt(l).Contains(tempCrossing[t])))
                                    {
                                        break;
                                    }
                                    flag2 = false;
                                }
                            }
                        }
                        if (flag2)
                        {
                            if (tempCrossing.Count == 0)
                            {
                                if (!(crossing.ElementAt(crossing.Count-1).Count==0))
                                    crossing.Add(tempCrossing);
                            }
                            else
                            crossing.Add(tempCrossing);
                        }
                    }
                }

                if (flag == crossing.Count())
                {
                    break;
                }
            }

            List<int> allElement = new List<int>();
            for (int i = 1; i < relations.size; i++)
            {
                allElement.Add(i);
            }

            bool flag4 = true;
            for (int l = 0; l < crossing.Count; l++)
            {
                if (allElement.Count == crossing.ElementAt(l).Count)
                {
                    for (int t = 0; t < crossing.ElementAt(l).Count; t++)
                    {
                        if (!(crossing.ElementAt(l).Contains(allElement[t])))
                        {
                            break;
                        }
                        flag4 = false;
                    }
                }
            }

            if (flag4)
            {
                crossing.Add(allElement);
            }

            List<List<List<int>>> neighbours = new List<List<List<int>>>();

            for (int i = 0; i < crossing.Count; i++)
            {
                neighbours.Add(new List<List<int>>());
                for (int j = 0; j < crossing.Count; j++)
                {
                    bool flag = true;
                    if (i != j)
                    {
                        for (int k = 0; k < crossing.ElementAt(i).Count; k++)
                        {
                            if (!(crossing.ElementAt(j).Contains(crossing.ElementAt(i)[k])))
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag && i!=j)
                    {
                        neighbours.ElementAt(i).Add(crossing.ElementAt(j));
                    }
                }
            }

            //идем по всем пересечениям
            for (int i = 0; i < crossing.Count; i++)
            {
                List < List < int >> temp = new List<List<int>>(neighbours.ElementAt(i));
                //по соседям пересечения
                for (int j = 0; j < temp.Count; j++)
                {
                    //ищем номер соседа в пересечении
                    int numb = 0;
                    for (int n = 0; n < crossing.Count; n++)
                    {
                        if (crossing.ElementAt(n).Count == temp[j].Count)
                        {
                            bool flag = true;
                            for (int l = 0; l < crossing.ElementAt(n).Count; l++)
                            {
                                if (!(crossing.ElementAt(n)[l] == temp[j][l]))
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                numb = n;
                                 break;
                            }
                        }
                    }
                    for (int n = 0; n < neighbours.ElementAt(numb).Count; n++)
                    {
                        if (temp.Contains(neighbours.ElementAt(numb)[n]))
                        {
                            neighbours.ElementAt(i).Remove(neighbours.ElementAt(numb)[n]);
                        }
                    }
                }
            }

            List<List<List<int>>> levels = new List<List<List<int>>>();
            levels.Add(neighbours.ElementAt(neighbours.Count - 1));

            bool flag3 = true;
            while (flag3)
            {
                levels.Add(new List<List<int>>());
                for (int i = 0; i < levels.ElementAt(levels.Count-2).Count; i++)
                {
                    int numb = 0;
                    for (int n = 0; n < crossing.Count; n++)
                    {
                        if (crossing.ElementAt(n).Count == levels.ElementAt(levels.Count - 2)[i].Count)
                        {
                            bool flag = true;
                            for (int l = 0; l < crossing.ElementAt(n).Count; l++)
                            {
                                if (!(crossing.ElementAt(n)[l] == levels.ElementAt(levels.Count - 2)[i][l]))
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                numb = n;
                                break;
                            }
                        }
                    }
                    for (int j = 0; j < neighbours.ElementAt(numb).Count; j++)
                    {
                        if (!(levels[levels.Count - 1].Contains(neighbours.ElementAt(numb)[j])))
                        {
                            levels[levels.Count - 1].Add(neighbours.ElementAt(numb)[j]);
                            if (neighbours.ElementAt(numb)[j].Count == relations.size)
                                flag3 = false;
                        }
                    }
                }
            }

            string alph = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < levels.Count; i++)
            {
                Console.WriteLine("{0} уровень:",i);
                foreach (var item in levels[i])
                {
                    List<int> temp = new List<int>();
                    Console.Write("{");
                    foreach (var num in item)
                    {
                        Console.Write(num+" ");
                        temp.Add(num);
                    }
                    Console.Write("}");

                    Console.Write("{");
                    for (int j = 0; j < relations.size; j++)
                    {
                        bool flag = true;
                        for (int j2 = 0; j2 < temp.Count; j2++)
                        {
                            if (relations.matrix[temp[j2] - 1, j] == 0)
                                flag = false;
                        }
                        if (flag)
                        {
                            Console.Write(alph.ElementAt(j)+" ");
                        }
                    }
                    Console.Write("}");
                }
                Console.WriteLine();
            }

            int index = 0;
            foreach (var item in crossing)
            {
                Console.Write("{");
                foreach (var num in item)
                {
                    Console.Write(num + " ");
                }
                Console.Write("}:");
                foreach (var neigb in neighbours[index])
                {
                        Console.Write("{");
                        foreach (var num in neigb)
                        {
                            Console.Write(num + " ");
                        }
                        Console.Write("}");
                }
                Console.WriteLine();
                index++;
            }
            
        }
    }
}
