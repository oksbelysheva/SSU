using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class GenerateMonocyclicTransposition
    {
        private List<int> transposition;

        public GenerateMonocyclicTransposition()
        {
            this.Size = ReadParametrN();
            if (this.Size == -1)
            {
                Console.WriteLine("Error: n.txt");
                return;
            }
            this.transposition = new List<int>(this.Size);
            this.IdenticalTransposition();
            this.SwapTransposition();
            this.transposition.Add(0);
            this.MonocyclicTransposition = new int[this.Size];
            this.MonocyclicTransposition[0] = this.transposition[0];
            for (int i = 1; i < this.Size; i++)
            {
                this.MonocyclicTransposition[this.transposition[i - 1]] = this.transposition[i];
            }

            this.PrintTransposition();
        }

        public static int ReadParametrN()
        {
            try
            {
                using (StreamReader sr = new StreamReader("n.txt"))
                {
                    string line = sr.ReadLine();
                    line.Trim();
                    return int.Parse(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: n.txt");
                Console.WriteLine(e.Message);
                return -1;
            }
            
        }

        private int[] MonocyclicTransposition { get; }

        private int Size { get; set; }

        private void PrintTransposition()
        {
            StringBuilder print = new StringBuilder();
            for (int i = 0; i < this.Size; i++)
            {
                print.Append((this.MonocyclicTransposition[i] + 1).ToString() + " ");
            }

            File.WriteAllText("key.txt", print.ToString());
        }

        private void SwapTransposition()
        {
            Random r = new Random();
            for (int i = 0; i < this.Size - 1; i++)
            {
                this.SwapElement(i, r.Next(this.Size - 1));
            }
        }

        private void SwapElement(int i, int j)
        {
            int temp = this.transposition[i];
            this.transposition[i] = this.transposition[j];
            this.transposition[j] = temp;
        }

        private void IdenticalTransposition()
        {
            for (int i = 0; i < this.Size - 1; i++)
            {
                this.transposition.Add(i + 1);
            }
        }
    }
}
