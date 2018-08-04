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
            Regex normalNotation = new Regex(@"^(((([+-]?[1-9][0-9]*)|(0{1}))\.[0-9]+)|(([+-]?[1-9][0-9]*)|(0{1})))$");
            Regex scienceNotation = new Regex(@"^(([+-]?[1-9][0-9]*)\.[0-9]+e((([+-]?[1-9][0-9]*)|(0{1}))))$");

            Console.WriteLine("Enter number:");
            string isNumber = Console.ReadLine();

            if (normalNotation.IsMatch(isNumber))
            {
                Console.WriteLine("This number in  normal notation");
            }
            else
            {
                if (scienceNotation.IsMatch(isNumber))
                {
                    Console.WriteLine("This number in  scientific notation");
                }
                else
                {
                    Console.WriteLine("This is not number");
                }
            }
        }
    }
}
