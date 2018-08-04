using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.BLL.Contracts;
using Epam.AwardsForUser.DAL.Contracts;
using Epam.AwardsForUser.DAL.Files;
using Epam.AwardsForUser.Entities;

namespace Epam.AwardsForUser.BLL.Core
{
    public class UserLogics : IUserLogic
    {
        public bool Add(User user)
        {
            user.Id = Guid.NewGuid();
            user.Age = DateTime.Now.Year - user.DateOfBirth.Year;
            if ((DateTime.Now.Month > user.DateOfBirth.Month) || ((DateTime.Now.Month == user.DateOfBirth.Month) && (DateTime.Now.Day >= user.DateOfBirth.Day)))
            {
                user.Age = DateTime.Now.Year - user.DateOfBirth.Year;
            }
            else
            {
                user.Age = DateTime.Now.Year - user.DateOfBirth.Year - 1;
            }

            user.SetAwards = new HashSet<int>();
            return Daos.UserDao.Add(user);
        }

        public bool AddAward(User user, int index)
        {
            return Daos.UserDao.AddAward(user, index);
        }

        public bool Delete(User user)
        {
            return Daos.UserDao.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return Daos.UserDao.GetAll().ToArray();
        }

        public void Save()
        {
            Daos.UserDao.Save();
        }
    }
}
