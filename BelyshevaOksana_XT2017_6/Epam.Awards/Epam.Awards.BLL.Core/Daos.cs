using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.DAL.Contracts;
using Epam.AwardsForUser.DAL.Files;

namespace Epam.AwardsForUser.BLL.Core
{
    public class Daos
    {
        static Daos()
        {
            UserDao = new UserDao();
            AwardDao = new AwardsDao();
        }

        internal static IUserDao UserDao { get; }

        internal static IAwardsDao AwardDao { get; }
    }
}
