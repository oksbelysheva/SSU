using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfRepresentetives
{
    class Relations
    {
        public int size;
        public int[,] matrix;

        public Relations()
        {
            try
            {
                String path = Directory.GetCurrentDirectory() + @"\set.txt";
                string text = File.ReadAllText(path);
                string[] str = text.Split();
                str = str.Where(x => x != "").ToArray();
                size = int.Parse(str[0]);
                matrix = new int[size, size];
                for (int i = 1; i < str.Length-1; i+=2)
                {
                    matrix[int.Parse(str[i]), int.Parse(str[i+1])] = 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка считывания set.txt");
                Console.ReadLine();
                return;
            }
        }

        public void EquivalentRelations()
        {
            this.reflexiveClosure();
            this.symmetricalClosure();
            this.transitiveClosure();
            String stringSet = String.Empty;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    stringSet += matrix[i, j] + " ";
                }
                stringSet += Environment.NewLine;
            }
            String path = Directory.GetCurrentDirectory() + @"\factor_set.txt";
            StreamWriter outputFile = new StreamWriter(path);
            outputFile.WriteLine(stringSet);
            outputFile.Flush();
            outputFile.Close();
        }

        public void RepresentiveSystem()
        {
            List<int> res = new List<int>();
            List <int[]> a = new List<int[]>();
            for (int i = 0; i < this.size; i++)
            {
                int[] row = new int[size];
                for (int j = 0; j < size; j++)
                {
                    row[j] = this.matrix[i, j];
                }

                bool flag = false;
                for (int j = 0; j < a.Count; j++)
                {
                    flag = true;
                    for (int k = 0; k < size; k++)
                    {
                        if (!(row[k] == a[j][k]))
                            flag = false;
                    }
                    if (flag)
                        break;
                }

                if (!flag)
                {
                    a.Add(row);
                    res.Add(i);
                }
            }
            Console.WriteLine("Система представителей:");
            for (int i = 0; i < res.Count; i++)
            {
                Console.WriteLine(res[i]+" ");
            }
        }

        private void reflexiveClosure()
        {
            for (int i = 0; i < this.size; i++)
                if (this.matrix[i, i] == 0) this.matrix[i, i]++;
        }

        private void symmetricalClosure()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.matrix[i,j] = this.matrix[i, j] | this.matrix[j, i];
                }
            }
        }

        private int[,] addMatrix(int[,] a, int[,] b, Relations r)
        {
            for (int i = 0; i < r.size; i++)
                for (int j = 0; j < r.size; j++)
                    a[i, j] |= b[i, j];
            return a;
        }

        private int[,] multiplyMatrix(int[,] a, int[,] b, Relations r)
        {
            int[,] res = new int[r.size, r.size];
            for (int i = 0; i < r.size; i++)
            {
                for (int j = 0; j < r.size; j++)
                {
                    for (int k = 0; k < r.size; k++)
                    {
                        res[i, j] |= a[i, k] & b[k, j];
                    }
                }
            }
            return res;
        }



        private void transitiveClosure()
        {
            
            for (int i = 0; i < this.size; i++)
                this.matrix = addMatrix(this.matrix, multiplyMatrix(this.matrix, this.matrix, this), this);
        }
    }
}
