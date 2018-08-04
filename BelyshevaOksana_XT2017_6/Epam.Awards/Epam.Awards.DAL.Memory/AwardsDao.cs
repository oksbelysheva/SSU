using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Awards.Entities;

namespace Epam.Awards.DAL.Memory
{
    class AwardsDao
    {
        private static IDictionary<Guid, User> users;

        static AwardsDao()
        {
            users = new Dictionary<Guid, User>();
        }

        public bool Add(User user)
        {
            if (users.ContainsKey(user.Id))
            {
                return false;
            }

            users.Add(user.Id, user);
            return true;
        }

        public bool Delete(User user)
        {
            if (!users.ContainsKey(user.Id))
            {
                return false;
            }

            users.Remove(user.Id);
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return users.Values;
        }
    }
}
