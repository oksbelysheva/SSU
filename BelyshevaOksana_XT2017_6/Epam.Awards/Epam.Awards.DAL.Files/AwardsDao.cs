using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.DAL.Contracts;
using Epam.AwardsForUser.Entities;

namespace Epam.AwardsForUser.DAL.Files
{
    public class AwardsDao : IAwardsDao
    {
        private static IDictionary<Guid, Awards> awards;

        static AwardsDao()
        {
            awards = new Dictionary<Guid, Awards>();
            var path = ConfigurationManager.AppSettings["PathAwards"];
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                FileStream fs = file.Create();
                fs.Close();
            }
            else
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string awardString = string.Empty;
                    while ((awardString = streamReader.ReadLine()) != null)
                    {
                        string[] splitString = awardString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Awards user = new Awards()
                        {
                            Id = new Guid(splitString[0]),
                            Title = splitString[1],
                        };
                        awards.Add(user.Id, user);
                    }
                }
            }
        }

        public bool Add(Awards award)
        {
            if (awards.ContainsKey(award.Id) || award.Title == string.Empty)
            {
                return false;
            }

            awards.Add(award.Id, award);
            return true;
        }

        public IEnumerable<Awards> GetAll()
        {
            return awards.Values;
        }

        public void Save()
        {
            var path = ConfigurationManager.AppSettings["PathAwards"];
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                var awards = this.GetAll();
                foreach (var award in awards)
                {
                    outputFile.WriteLine($"{award.Id} {award.Title}");
                }

                outputFile.Flush();
                outputFile.Close();
            }
        }
    }
}
