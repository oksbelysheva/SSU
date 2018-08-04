using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.Entities;

namespace Epam.AwardsForUser.DAL.Contracts
{
    public interface IAwardsDao
    {
        bool Add(Awards user);

        void Save();

        IEnumerable<Awards> GetAll();
    }
}
