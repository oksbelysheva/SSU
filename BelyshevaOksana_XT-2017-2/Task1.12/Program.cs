using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            StringBuilder str1 = new StringBuilder(Console.ReadLine());
            Console.Write("Введите вторую строку: ");
            string str2 = Console.ReadLine();
            str2 = new string(str2.Distinct().ToArray());
            for (int i = 0; i < str2.Length; i++)
            {
                string doubleLetter = str2.ElementAt(i).ToString() + str2.ElementAt(i).ToString();
                str1.Replace(str2.ElementAt(i).ToString(), doubleLetter);
            }

            Console.WriteLine("Результат: {0}", str1);
        }
    }
}
