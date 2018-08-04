using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.BLL.Contracts;
using Epam.AwardsForUser.Entities;

namespace Epam.AwardsForUser.BLL.Core
{
    public class AwardLogics : IAwardLogic
    {
        public bool Add(Awards awards)
        {
            awards.Id = Guid.NewGuid();
            return Daos.AwardDao.Add(awards);
        }

        public IEnumerable<Awards> GetAll()
        {
            return Daos.AwardDao.GetAll().ToArray();
        }

        public void Save()
        {
            Daos.AwardDao.Save();
        }
    }
}
