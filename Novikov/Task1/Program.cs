using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1 - Сгенерировать случайную моноциклическую перестановку\n" +
                "2 - Зашифровать текст шифром простой перестановки\n" +
                "3 - Расшифровать текст при помощи известного ключа\n" +
                "4 - Выполнить тест Казиски\n" +
                "5 - По полученной длине ключа из теста Казиски, восстановить сообщение");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        GenerateMonocyclicTransposition transposition = new GenerateMonocyclicTransposition();
                        break;
                    }
                case 2:
                    {
                        Cryptogram cryptogram = new Cryptogram();
                        break;
                    }
                case 4:
                    {
                        Kasiski kasiski1 = new Kasiski(7);
                        Kasiski kasiski2 = new Kasiski(5);
                        Kasiski kasiski3 = new Kasiski(6);
                        int temp =  GCD(kasiski1.answer, kasiski2.answer);
                        int result = GCD(temp, kasiski3.answer);
                        File.WriteAllText("anticipatedN.txt", result.ToString());
                        break;
                    }
                case 3:
                    {
                        Decipher decipher = new Decipher();
                        break;
                    }
                case 5:
                    {
                        GenerateAllMonocyclicTransposition generateAllMonocyclicTransposition = new GenerateAllMonocyclicTransposition();
                        break;
                    }
            }
            
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GCD(b, a % b);
            }
        }
    }
}
