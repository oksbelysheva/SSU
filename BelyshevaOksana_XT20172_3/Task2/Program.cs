using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string text = Console.ReadLine();
            string[] words = text.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> frequencyWord = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string lowerWord = words[i].ToLower();
                if (frequencyWord.ContainsKey(lowerWord))
                {
                    frequencyWord[lowerWord]++;
                }
                else
                {
                    frequencyWord.Add(lowerWord, 1);
                }
            }

            Console.WriteLine("{0,-20} {1,5}\n", "Word", "Frequancy");
            foreach (var item in frequencyWord)
            {
                Console.WriteLine("{0,-20} {1,5}", item.Key.ToString(), ((double)item.Value / words.Length).ToString());
            }
        }
    }
}
