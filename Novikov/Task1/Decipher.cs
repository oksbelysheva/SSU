using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Decipher
    {
        private int[] Key;

        private int N { get; set; }

        private int[] ReadKey()
        {
            int[] resultRead = new int[this.N];
            try
            {
                using (StreamReader sr = new StreamReader("key.txt"))
                {
                    string line = sr.ReadLine();
                    string[] lineSplit = line.Split();
                    for (int i = 0; i < this.N; i++)
                    {
                        resultRead[i] = int.Parse(lineSplit[i]);
                    }
                    return resultRead;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: key.txt");
                Console.WriteLine(e.Message);
                return null;
            }
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

        private void PrintDecipher(String message)
        {
            File.WriteAllText("decipher.txt", message);
        }

        public Decipher()
        {
            this.N = GenerateMonocyclicTransposition.ReadParametrN();
            this.Key = ReadKey();
            if (this.Key == null || this.Key.Length != N)
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
                String partCryptogram = cryptogram.Substring(position, this.N);
                char[] temp = new char[this.N];
                for (int i = 0; i < this.N; i++)
                {
                    temp[i] = partCryptogram[Key[i] - 1];
                }
                decipher.Append(temp);
                position += this.N;
            }
            PrintDecipher(decipher.ToString());

        }

        public Decipher(int n, int[] key)
        {
            if (key == null || key.Length != n)
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
                String partCryptogram = cryptogram.Substring(position, n);
                char[] temp = new char[n];
                for (int i = 0; i < n; i++)
                {
                    temp[i] = partCryptogram[key[i] - 1];
                }
                decipher.Append(temp);
                position += n;
            }
            PrintDecipher(decipher.ToString());
        }
    }
}
