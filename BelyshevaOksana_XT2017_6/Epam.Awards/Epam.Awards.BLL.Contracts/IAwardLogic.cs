using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.Entities;

namespace Epam.AwardsForUser.BLL.Contracts
{
    public interface IAwardLogic
    {
        bool Add(Awards user);

        IEnumerable<Awards> GetAll();

        void Save();
    }
}
