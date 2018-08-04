using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3SystemComprasions
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

        public struct Equation
        {
            public int s;
            public int p;

            public Equation(int s, int p)
            {
                this.s = s;
                this.p = p;
            }
        }

        static void Main(string[] args)
        {
            int a, b, m;
            string path = Directory.GetCurrentDirectory() + @"\input.txt";
            string text = File.ReadAllText(path);
            string[] words = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<Equation> input = new List<Equation>();
            for (int i = 0; i < words.Length; i+=2)
            {
                Equation current = new Equation(int.Parse(words[i]), int.Parse(words[i+1]));
                input.Add(current);
            }
            int[] res = SystemComprasion(input);
            if (res.Length>0)
            Console.WriteLine("Решение системы сравнений: x0 = {0} (mod {1})", res[0], res[1]);
        }

        private static int[] SystemComprasion(List<Equation> equations)
        {
            int d = 1;
            for (int i = 0; i < equations.Count; i++)
            {
                d *= equations[i].p;
                for (int j = 0; j < equations.Count; j++)
                {
                    if (i != j && binarEuclidean(equations[i].p, equations[j].p) != 1)
                    {
                        Console.WriteLine("Решения не существует");
                        return new int[0];
                    }
                }
            }
            int x0 = 0;

            for (int i = 0; i < equations.Count; i++)
            {
                int s1 = equations[i].s;
                int p1 = equations[i].p;
                int d1 = d / p1;
                int dHatch = InverseMod(d1, p1);
                x0 += d1 * dHatch * s1;
            }
            int[] res = new int[2];
            res[0] = x0 % d;
            res[1] = d;
            return res;
        }
        private static int InverseMod(int a, int m)
        {
            if (binarEuclidean(a, m) != 1)
            {
                Console.WriteLine("Нет решения!");
                return -1;
            }
            else
            {
                int[] solutions = FindAnswerFirsDegreeComparisons(a, 1, m);
                return solutions[0];
            }
        }
    }
}
