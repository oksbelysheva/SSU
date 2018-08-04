using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Regex regex = new Regex("<.*?>");

            Console.WriteLine("Enter text:");
            string text = Console.ReadLine();
            text = regex.Replace(text, "_");

            Console.WriteLine("Result: " + text);
        }
    }
}
