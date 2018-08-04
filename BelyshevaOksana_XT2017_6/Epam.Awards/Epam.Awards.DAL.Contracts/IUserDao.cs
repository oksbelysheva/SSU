using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.Entities;

namespace Epam.AwardsForUser.DAL.Contracts
{
    public interface IUserDao
    {
        bool Add(User user);

        bool Delete(User user);

        void Save();

        IEnumerable<User> GetAll();

        bool AddAward(User user, int index);
    }
}
