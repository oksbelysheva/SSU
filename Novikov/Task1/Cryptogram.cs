using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Cryptogram
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

        public Cryptogram()
        {
            this.N = GenerateMonocyclicTransposition.ReadParametrN();
            this.Key = ReadKey();
            if (this.Key == null || this.Key.Length != N)
            {
                Console.WriteLine("Error: key.txt");
                return;
            }
            String message = ReadMessage();
            if (message == null)
            {
                Console.WriteLine("Error: message.txt");
                return;
            }

            StringBuilder cryptograma = new StringBuilder();

            Random random = new Random();
            int position = 0;

            for (int i = 0; i <= message.Length%this.N; i++)
            {
                //message = message + (message[new Random().Next(0, message.Length)]);
                message = message + " ";
            }
            
            while (position < message.Length)
            {
                String partDecipher = message.Substring(position, this.N);
                char[] temp = new char[this.N];
                for (int i = 0; i < this.N; i++)
                {
                    temp[Key[i] - 1] = partDecipher[i];
                }
                cryptograma.Append(temp);
                position += this.N;
            }




            PrintCryptogram(cryptograma.ToString());

        }

        private string ReadMessage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader("message.txt", Encoding.GetEncoding(1251)))
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
                Console.WriteLine("Error: message.txt");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private void PrintCryptogram(String message) {
            File.WriteAllText("cryptogram.txt", message, Encoding.GetEncoding(1251));
        }
    }
}
