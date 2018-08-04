using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task28
{
    class Bonus : ObjectOnField
    {
        private int countBonus;
        public Bonus(Field f)
        {
            CurrentCoordinate = new Point(f);
            Random random = new Random(10);
            CountBonus = random.Next();
            Console.WriteLine("Бонус с значением {0} располагается на координатах({1},{2})", countBonus.ToString(), CurrentCoordinate.x.ToString(), CurrentCoordinate.y.ToString());
        }

        public int CountBonus
        {
            get
            {
                return this.countBonus;
            }

            set
            {
                this.countBonus = value;
            }
        }

        public void ChangeHealthUser(User user) => user.Health+= CountBonus;
    }
}
