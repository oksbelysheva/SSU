using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class GenerateAllMonocyclicTransposition
    {
        private static int AnticipatedN = ReadAnticipatedN();
        private static int[] transposition;
        private static StringBuilder AllDecipher = new StringBuilder();

        public static List<int[]> ans = new List<int[]>();

        public static int ReadAnticipatedN()
        {
            try
            {
                using (StreamReader sr = new StreamReader("anticipatedN.txt"))
                {
                    string line = sr.ReadLine();
                    line.Trim();
                    return int.Parse(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: anticipatedN.txt");
                Console.WriteLine(e.Message);
                return -1;
            }

        }

        private static void SwapElement(int i, int j)
        {
            int temp = transposition[i];
            transposition[i] = transposition[j];
            transposition[j] = temp;
        }

        public static bool IsCorrect(int[] arr)
        {
            int first = arr[0];
            int temp = first;
            int i = 0;
            while (i < arr.Length && first != arr[temp - 1])
            {
                i++;
                temp = arr[temp - 1];
            }
            return i == arr.Length - 1 && first == arr[temp - 1];
        }

        public static void GenerateMonocyclicTransposition(int k)//генерация всех перестановок длины n 
        {
            if (k == AnticipatedN)
            {
                if (IsCorrect(transposition))
                {
                    Decipher((int[])transposition.Clone());
                    ans.Add((int[])transposition.Clone());
                }
            } else
            {
                for (int j = k; j < transposition.Length; j++)
                {
                    SwapElement(k,j);
                    GenerateMonocyclicTransposition(k+1);
                    SwapElement(k,j);
                }
            }
        }

        public GenerateAllMonocyclicTransposition()
        {
            IdenticalTransposition();
            GenerateMonocyclicTransposition(0);
            string[] stringAns = new string[ans.Count];
            for (int i = 0; i < ans.Count; i++)
            {
                StringBuilder temp = new StringBuilder();
                for (int j = 0; j < AnticipatedN; j++)
                {
                    temp.Append(ans[i][j]);
                    temp.Append(' ');
                }
                stringAns[i] = temp.ToString();
            }
            File.WriteAllLines("allMonocyclicTransposition.txt", stringAns);
            PrintDecipher(AllDecipher.ToString());
        }

        private static void IdenticalTransposition()
        {
            transposition = new int[AnticipatedN];
            for (int i = 0; i < AnticipatedN; i++)
            {
                transposition[i] = i + 1;
            }
        }

        private static string ReadCryptogram()
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

        public static void Decipher(int[] key)
        {
            if (key == null || key.Length != AnticipatedN)
            {
                Console.WriteLine("Error: key.txt");
                return;
            }
            String cryptogram = ReadCryptogram();
            if (cryptogram == null)
            {
                Console.WriteLine("Error: cryptogram.txt");
                return;
            }

            StringBuilder decipher = new StringBuilder();
            Random random = new Random();
            int position = 0;
            while (position < cryptogram.Length)
            {
                String partCryptogram = cryptogram.Substring(position, AnticipatedN);
                char[] temp = new char[AnticipatedN];
                for (int i = 0; i < AnticipatedN; i++)
                {
                    temp[key[i] - 1] = partCryptogram[i];
                }
                decipher.Append(temp);
                position += AnticipatedN;
            }
            AllDecipher.Append(decipher);
            AllDecipher.AppendLine();
            AllDecipher.AppendLine();
        }

        private void PrintDecipher(String message)
        {
            File.WriteAllText("allDecipher.txt", message);
        }
    }
}
