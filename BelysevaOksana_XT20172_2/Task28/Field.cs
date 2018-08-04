using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task28
{
    public class Field
    {
        public static int Width { get; private set; }

        public static int Height { get; private set; }

        static Field()
        {
            Random rand = new Random();
            Width = rand.Next();
            Height = rand.Next();
        }

        public static void ShowInfoField()
        {
            Console.WriteLine("Характеристики поля:");
            Console.WriteLine("Ширина: {0}", Width.ToString());
            Console.WriteLine("Высота: {0}", Height.ToString());
        }

    }
}
