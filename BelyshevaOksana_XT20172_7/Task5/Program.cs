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
            Regex regex = new Regex("(([0-1]?[0-9])|(2[0-3])):([0-5][0-9])");

            Console.WriteLine("Enter text:");

            Console.WriteLine($"Count time: {regex.Matches(Console.ReadLine()).Count.ToString()}");
        }
    }
}
