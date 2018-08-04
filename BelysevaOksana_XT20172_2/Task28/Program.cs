using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task28
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();

            List<ObjectOnField> listObjectOnField = new List<ObjectOnField>();

            listObjectOnField.Add(new Obstacle(field));
            listObjectOnField.Add(new Monster(field));       
            listObjectOnField.Add(new Bonus(field));

            User user = new User("Oksana", field);
        }
    }
}
