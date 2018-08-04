using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task27
{
    class Line : Figure
    {
        public double K { get; set; }

        public double B { get; set; }

        public Line(double b, double k)
        {
            this.B = b;
            this.K = k;
        }

        public override void Print()
        {
            Console.WriteLine("Прямая: ");
            Console.WriteLine("y = {0}x+{1}", this.K.ToString(), this.B.ToString());
            Console.WriteLine();
        }
    }
}
