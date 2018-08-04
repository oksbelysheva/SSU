using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._6
{
    public class Program
    {
        [Flags]
        public enum InscriptionParameters
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        public static void Main(string[] args)
        {
            InscriptionParameters currentState = InscriptionParameters.None;
            Console.WriteLine("Параметры надписи: {0}", currentState);
            Console.WriteLine("Введите:{0}\t1.bold{0}\t2.italic{0}\t3.underline", Environment.NewLine);

            int state = 0;
            while (int.TryParse(Console.ReadLine(), out state))
            {
                if (!(state >= 1 && state <= 3))
                {
                    break;
                }

                switch (state)
                {
                    case 1:
                        currentState = currentState ^ InscriptionParameters.Bold;
                        break;
                    case 2:
                        currentState = currentState ^ InscriptionParameters.Italic;
                        break;
                    case 3:
                        currentState = currentState ^ InscriptionParameters.Underline;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Параметры надписи: {0}", currentState);
                Console.WriteLine("Введите:{0}\t1.bold{0}\t2.italic{0}\t3.underline", Environment.NewLine);
            }
        }
    }
}
