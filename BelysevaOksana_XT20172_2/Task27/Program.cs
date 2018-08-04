using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task27
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = new Figure[5];
            figures[0] = new Line(3, 8);
            figures[1] = new Circle(5, 6, 8);
            figures[2] = new Round(4, 8, 6);
            figures[3] = new Ring(4, 6, 5, 6);
            figures[4] = new Rectangle(7, 8, 4, 0);

            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Print();
            }
        }
    }
}
