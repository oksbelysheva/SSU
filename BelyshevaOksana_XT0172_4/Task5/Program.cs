using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] test = { "0001", "1+2", "-3", "+0005", "123", "0000", "+0", "+0000" };
            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine($"{test[i]} {test[i].IsDigit()}");
            }
        }
    }
}
