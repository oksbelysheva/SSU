using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task28
{
    class Monster : ObjectOnField, ICreature
    {
        private int health;
        private string name;
        private Point currentCoordinate;

        public Monster(Field f)
        {
            this.Health = 50;
            this.СurrentCoordinate = new Point(f);
            String[] typeArray = { "волк", "медведь", "тигр" };
            Random rand = new Random();
            this.Name = typeArray[rand.Next(0,2)];

            Console.WriteLine("Характеристики монстра");
            Console.WriteLine("Тип: {0}", name.ToString());
            Console.WriteLine("Колличество жизни: {0}", Health.ToString());
            Console.WriteLine("Координаты = монстра: x = {0}, y = {1}", СurrentCoordinate.x.ToString(), СurrentCoordinate.y.ToString());
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (this.Health + value == 0)
                {
                    Console.WriteLine("Killed");
                }

                this.health += value;
            }
        }

        public Point СurrentCoordinate
        {
            get
            {
                return this.currentCoordinate;
            }
            set
            {
                this.currentCoordinate = value;
            }
        }

        public void MoveToDown()
        {
            this.currentCoordinate.y--;
        }

        public void MoveToLeft()
        {
            this.currentCoordinate.x--;
        }

        public void MoveToRight()
        {
            this.currentCoordinate.x++;
        }

        public void MoveToUp()
        {
            this.currentCoordinate.y++;
        }
    }
}
