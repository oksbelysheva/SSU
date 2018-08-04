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
            Regex regex = new Regex(@"[A-Za-z0-9][A-Za-z0-9\.\-_]*[A-Za-z0-9]@([A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9]\.)+[A-Za-z]{2,6}");

            Console.WriteLine("Enter text:");

            foreach (var item in regex.Matches(Console.ReadLine()))
            {
                Console.WriteLine(item);
            }
        }
    }
}
