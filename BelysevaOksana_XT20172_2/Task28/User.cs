using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task28
{
    public class User : ObjectOnField, ICreature
    {
        private int health;
        private string nickname;
        private Point currentCoordinate;

        public User(string nickname, Field f)
        {
            this.Health = 100;
            this.СurrentCoordinate = new Point(f);
            this.Name = nickname;

            Console.WriteLine("Характеристики игрока");
            Console.WriteLine("Имя: {0}", this.Name.ToString());
            Console.WriteLine("Колличество жизни: {0}", this.Health.ToString());
            Console.WriteLine("Координаты игрока: x = {0}, y = {1}", this.currentCoordinate.x.ToString(), this.СurrentCoordinate.y.ToString());
        }

        public string Name
        {
            get
            {
                return this.nickname;
            }

            set
            {
                if (value.Length < 2 || value.Length > 100)
                {
                    throw new Exception("Ошибка: длина имени больше двух символов и меньше ста");
                }
                this.nickname = value;
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
                    Console.WriteLine("You lose");
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
