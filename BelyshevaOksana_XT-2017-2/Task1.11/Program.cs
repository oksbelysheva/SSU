using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, в которой необходимо узнать среднюю длину слова");
            string str = Console.ReadLine();
            string[] splitted = str.Split(new[] { '-', '.', '?', '!', ')', '(', ',', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int wordsStr = 0;
            foreach (var word in splitted)
            {
                wordsStr += word.Length;
            }

            Console.WriteLine("Средняя длина слова: {0}", wordsStr / splitted.Length);
        }
    }
}
