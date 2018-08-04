using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1SolutionsFirstDegree
{
    class Program
    {
        public static int[] FindAnswerFirsDegreeComparisons(int a, int b, int m)
        {
            int d = binarEuclidean(a, m);
            if (b % d != 0)
            {
                return new int[0];
            }
            else
            {
                int a1 = a / d;
                int b1 = b / d;
                int m1 = m / d;
                int x, y;
                int temp = ExtandEuclidean(a1, m1, out x, out y);
                while (x < 0)
                {
                    x = x + m1;
                }
                int x0 = (b1 * x) % m1;
                int[] solutions = new int[d];
                for (int i = 0; i < solutions.Length; i++)
                {
                    solutions[i] = x0 + m1 * i;
                }
                return solutions;
            }

        }

        public static int ExtandEuclidean(int a, int b, out int x, out int y)
        {
            int d;
            List<int> r = new List<int>();
            r.Add(a);
            r.Add(b);
            List<int> X = new List<int>();
            X.Add(1);
            X.Add(0);
            List<int> Y = new List<int>();
            Y.Add(0);
            Y.Add(1);
            for (int i = 1; ; i++)
            {
                int q = r[i - 1] / r[i];
                r.Add(r[i - 1] % r[i]);
                if (r[i + 1] == 0)
                {
                    d = r[i];
                    x = X[i];
                    y = Y[i];
                    return d;
                }
                else
                {
                    X.Add(X[i - 1] - q * X[i]);
                    Y.Add(Y[i - 1] - q * Y[i]);
                }
            }
        }

        public static int binarEuclidean(int a, int b)
        {
            int g = 1;
            while (a % 2 == 0 && b % 2 == 0)
            {
                a = a / 2;
                b = b / 2;
                g *= 2;
            }
            int u = a, v = b;
            while (u != 0)
            {
                while (u % 2 == 0)
                {
                    u /= 2;
                }
                while (v % 2 == 0)
                {
                    v /= 2;
                }
                if (u >= v) u = u - v;
                else v = v - u;

            }
            return g * v;
        }

        static void Main(string[] args)
        {
            int a, b, m;
            string path = Directory.GetCurrentDirectory() + @"\input.txt";
            string text = File.ReadAllText(path);
            string[] words = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            a = int.Parse(words[0]);
            b = int.Parse(words[1]);
            m = int.Parse(words[2]);
            int[] res = FindAnswerFirsDegreeComparisons(a, b, m);
            if (res.Length > 0)
            {
                Console.WriteLine("Решение сравнения: ");
                for (int i = 0; i < res.Length; i++)
                {
                    Console.WriteLine("x{0} = {1}", i, res[i]);
                }
            }
            else
                Console.WriteLine("Решения не существует");
        }
    }
}
