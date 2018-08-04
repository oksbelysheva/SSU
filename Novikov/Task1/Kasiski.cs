using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Kasiski
    {
        private class Pair
        {
            public int Index { get; set; }//индекс элемента в массиве
            public int Value { get; set; }//значение элемента в массиве
        }

        private string ReadCryptogram()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader("cryptogram.txt", Encoding.GetEncoding(1251)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        stringBuilder.Append(line);
                    }
                    return stringBuilder.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: cryptogram.txt");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        
        public static int lengthCoincidingSymbols = 5;

        public static int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return gcd(b, a % b);
            }
        }

        public int answer;

        public Kasiski(int length)
        {
            lengthCoincidingSymbols = length;
            string cryptogram = ReadCryptogram();
            List<int> repeatCount = new List<int>();
            for (int i = 0; i < cryptogram.Length - lengthCoincidingSymbols + 1; i++)
            {
                string temp = cryptogram.Substring(i, lengthCoincidingSymbols);
                for (int j = i + lengthCoincidingSymbols; j < cryptogram.Length - lengthCoincidingSymbols + 1; j++)
                {
                    string temp2 = cryptogram.Substring(j, lengthCoincidingSymbols);
                    if (temp.Equals(temp2))
                    {
                        repeatCount.Add(j - i);
                    }
                }
            }
            int[] nods = new int[5000];
            for (int i = 0; i < repeatCount.Count; ++i)
                for (int j = i + 1; j < repeatCount.Count; ++j)
                {
                    int x = gcd(repeatCount[i], repeatCount[j]);
                    if (x < 5000)
                        nods[x]++;
                }
            nods[0] = 0;
            List<Pair> ans= new List<Pair>();
            for (int i = 2; i < 500; ++i)
            {
                ans.Add(new Pair(){ Index = i, Value = nods[i] });
            }
            IEnumerable<Pair> anss = ans.OrderByDescending(p => p.Value).Take(10);
            string stringAns = "";
            List<int> resNod = new List<int>();
            foreach (var s in anss)
            {
                if (s.Value > 0)
                {
                    stringAns += s.Index + " ";
                    resNod.Add(s.Index);
                }
            }
            answer = 2;
            int pos = 0;
            for (int i = 0; i <= resNod.Count; i++)
            {
                if (resNod[i] != 1 && resNod[i] != 2)
                {
                    answer = resNod[i];
                    pos = i;
                    break;
                }
            }
            for (int i = pos; i < resNod.Count(); i++)
            {
                int temp = gcd(answer, resNod[i]);
                if (temp != 1 && temp != 2)
                    answer = temp;
            }
            using (StreamWriter sw = File.AppendText("kasiski.txt"))
            {
                sw.WriteLine(stringAns);
            }
        }
    }
}