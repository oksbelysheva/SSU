using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.Entities;

namespace Epam.AwardsForUser.BLL.Contracts
{
    public interface IUserLogic
    {
        bool Add(User user);

        bool Delete(User user);

        IEnumerable<User> GetAll();

        void Save();

        bool AddAward(User user, int index);
    }
}
