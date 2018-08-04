using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task28
{
    class Obstacle : ObjectOnField
    {
        public Obstacle(Field f)
        {
            Point coordinate = new Point(f);
            String[] typeArray = {"дерево", "камень", "лужа"};
            Random rand = new Random();
            String type = typeArray[rand.Next(0,2)];

            Console.WriteLine("Препятствие {0} создано с координатами X = {1}, Y = {2}", type, coordinate.x.ToString(), coordinate.y.ToString());
        }
    }
}
