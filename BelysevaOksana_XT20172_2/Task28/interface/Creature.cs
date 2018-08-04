using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task28
{
    public interface ICreature
    {
        string Name { get; set; }

        int Health { get; set; }

        void MoveToUp();

        void MoveToDown();

        void MoveToLeft();

        void MoveToRight();
    }
}
    
