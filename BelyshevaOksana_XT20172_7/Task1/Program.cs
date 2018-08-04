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
            Regex regex = new Regex("((0[1-9])|([1-2][0-9])|(3[0-1]))-((0[1-9])|(1[0-2]))-((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9]{2})|([1-9][0-9]{3}))");

            Console.WriteLine("Enter text:");

            if (regex.IsMatch(Console.ReadLine()))
            {
                Console.WriteLine("The text contains a date");
            }
            else
            {
                Console.WriteLine("Text does not contain a date");
            }
        }
    }
}
