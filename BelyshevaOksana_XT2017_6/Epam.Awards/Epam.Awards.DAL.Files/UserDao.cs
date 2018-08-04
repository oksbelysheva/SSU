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
    public class UserDao : IUserDao
    {
        private static IDictionary<Guid, User> users;

        static UserDao()
        {
            users = new Dictionary<Guid, User>();
            var path = ConfigurationManager.AppSettings["PathUser"];
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
                    string userString = string.Empty;
                    while ((userString = streamReader.ReadLine()) != null)
                    {
                        string[] splitString = userString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string awardsString;
                        if ((awardsString = streamReader.ReadLine()) == null || !awardsString.Contains("Awards:"))
                        {
                            Console.WriteLine("Error: format of user.txt is incorrect. user.txt will be deleted.");
                            streamReader.Close();
                            file.Delete();
                            users = new Dictionary<Guid, User>();
                            return;
                        }

                        awardsString = awardsString.Substring(awardsString.IndexOf(":") + 1);
                        string[] splitAwards = awardsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] intAwards = Array.ConvertAll(splitAwards, delegate(string s) { return int.Parse(s); });
                        User user = new User()
                        {
                            Id = new Guid(splitString[0]),
                            Name = splitString[1],
                            DateOfBirth = DateTime.Parse(splitString[2]),
                            Age = int.Parse(splitString[3]),
                            SetAwards = new HashSet<int>(intAwards),
                        };
                        users.Add(user.Id, user);
                    }
                }
            }
        }

        public bool Add(User user)
        {
            if (users.ContainsKey(user.Id) || this.CheckUser(user))
            {
                return false;
            }

            users.Add(user.Id, user);
            return true;
        }

        public bool AddAward(User user, int index)
        {
            return users[user.Id].SetAwards.Add(index);
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

        public void Save()
        {
            var path = ConfigurationManager.AppSettings["PathUser"];
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                var users = this.GetAll();
                foreach (var user in users)
                {
                    outputFile.WriteLine($"{user.Id} {user.Name} {user.DateOfBirth.ToString("dd/MM/yyyy")} {user.Age}");
                    outputFile.Write("Awards: ");
                    foreach (var award in user.SetAwards)
                    {
                        outputFile.Write($"{award} ");
                    }

                    outputFile.WriteLine();
                }

                outputFile.Flush();
                outputFile.Close();
            }
        }

        private bool CheckUser(User user)
        {
            return user.Name == string.Empty || user.Age < 0 || user.Age >= 150 || user.DateOfBirth > DateTime.Now;
        }
    }
}
