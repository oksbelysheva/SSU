using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.AwardsForUser.BLL.Contracts;
using Epam.AwardsForUser.BLL.Core;
using Epam.AwardsForUser.Entities;

namespace Epam.AwardsForUser.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUserLogic userLogic = new UserLogics();
            IAwardLogic awardLogic = new AwardLogics();
            int caseChoice = -1;
            while (caseChoice != 0)
            {
                Console.WriteLine("1 - Work with user");
                Console.WriteLine("2 - Work with awards");
                Console.WriteLine("3 - Work with user add award");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("Enter your choice:");
                int.TryParse(Console.ReadLine(), out caseChoice);
                switch (caseChoice)
                {
                    case 1:
                        {
                            WorkWithUser(userLogic, awardLogic);
                            break;
                        }

                    case 2:
                        {
                            WorkWithAwards(awardLogic);
                            break;
                        }

                    case 3:
                        {
                            WorkWithUserAddAwards(userLogic, awardLogic);
                            break;
                        }

                    case 0:
                    default:
                        return;
                }
            }
        }

        private static void WorkWithUserAddAwards(IUserLogic userLogic, IAwardLogic awardLogic)
        {
            Console.Clear();
            int caseChoice = -1;
            while (caseChoice != 0)
            {
                Console.WriteLine("1 - Add award user");
                Console.WriteLine("2 - Save added awards");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("Enter your choice:");
                int.TryParse(Console.ReadLine(), out caseChoice);
                switch (caseChoice)
                {
                    case 1:
                        {
                            AddAwardsUser(userLogic, awardLogic);
                            break;
                        }

                    case 2:
                        {
                            Save(userLogic);
                            break;
                        }

                    case 0:
                    default:
                        {
                            Console.Clear();
                            return;
                        }
                }
            }
        }

        private static void AddAwardsUser(IUserLogic userLogic, IAwardLogic awardLogic)
        {
            Console.Clear();
            Print(userLogic, awardLogic);
            Console.WriteLine("Enter user id: ");
            var userId = Console.ReadLine();
            var users = userLogic.GetAll();
            User user;
            if (int.TryParse(userId, out int id) && id >= 0 && users.Count() - 1 >= id)
            {
                user = users.ElementAt(int.Parse(userId));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error: User index does not exist");
                return;
            }
            
            Print(awardLogic);
            Console.WriteLine("Enter award id: ");
            var awardId = Console.ReadLine();
            var awards = awardLogic.GetAll();
            if (int.TryParse(awardId, out id) && id >= 0 && awards.Count() - 1 >= id)
            {
                if (userLogic.AddAward(user, id))
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error: This user already has this award");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error: Award index does not exist");
                return;
            }
        }

        private static void WorkWithAwards(IAwardLogic logic)
        {
            Console.Clear();
            int caseChoice = -1;
            while (caseChoice != 0)
            {
                Console.WriteLine("1 - Add awards");
                Console.WriteLine("2 - Show all awards");
                Console.WriteLine("3 - Save");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("Enter your choice:");
                int.TryParse(Console.ReadLine(), out caseChoice);

                switch (caseChoice)
                {
                    case 1:
                        {
                            AddAward(logic);
                            break;
                        }

                    case 2:
                        {
                            GetAll(logic);
                            break;
                        }

                    case 3:
                        {
                            Save(logic);
                            break;
                        }

                    case 0:
                    default:
                        {
                            Console.Clear();
                            return;
                        }
                }
            }
        }

        private static void WorkWithUser(IUserLogic userLogic, IAwardLogic awardLogic)
        {
            Console.Clear();
            int caseChoice = -1;
            while (caseChoice != 0)
            {
                Console.WriteLine("1 - Add user");
                Console.WriteLine("2 - Delete user");
                Console.WriteLine("3 - Show all users");
                Console.WriteLine("4 - Save");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("Enter your choice:");
                int.TryParse(Console.ReadLine(), out caseChoice);

                switch (caseChoice)
                {
                    case 1:
                        {
                            AddUser(userLogic);
                            break;
                        }

                    case 2:
                        {
                            DeleteUser(userLogic, awardLogic);
                            break;
                        }

                    case 3:
                        {
                            GetAll(userLogic, awardLogic);
                            break;
                        }

                    case 4:
                        {
                            Save(userLogic);
                            break;
                        }

                    case 0:
                    default:
                        {
                            Console.Clear();
                            return;
                        }
                }
            }
        }

        private static void AddUser(IUserLogic logic)
        {
            Console.Clear();
            Console.WriteLine("Enter user name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter user date of birth: ");
            var dateOfBirth = Console.ReadLine();

            if (DateTime.TryParse(dateOfBirth, out DateTime date))
            {
                var user = new User()
                {
                    Name = name,
                    DateOfBirth = date,
                };
                if (logic.Add(user))
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error: user's data is incorrect");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error: user's birth date is incorrect (required dd/MM/yyyy)");
            }
        }

        private static void AddAward(IAwardLogic logic)
        {
            Console.Clear();
            Console.WriteLine("Enter award title: ");
            var title = Console.ReadLine();

            var award = new Awards()
            {
                Title = title,
            };
            logic.Add(award);
            Console.Clear();
        }

        private static void DeleteUser(IUserLogic userLogic, IAwardLogic awardLogic)
        {
            Console.Clear();
            Print(userLogic, awardLogic);
            Console.WriteLine("Enter id: ");
            var idString = Console.ReadLine();
            if (int.TryParse(idString, out int id) && id >= 0 && userLogic.GetAll().Count() - 1 >= id)
            {
                var users = userLogic.GetAll();
                User user = users.ElementAt(id);
                userLogic.Delete(user);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error: User index does not exist");
            }
        }

        private static void GetAll(IUserLogic logic, IAwardLogic awardLogic)
        {
            Console.Clear();
            Print(logic, awardLogic);
            Console.ReadKey();
            Console.Clear();
        }

        private static void GetAll(IAwardLogic logic)
        {
            Console.Clear();
            Print(logic);
            Console.ReadKey();
            Console.Clear();
        }

        private static void Save(IUserLogic logic)
        {
            Console.Clear();
            logic.Save();
            Console.Clear();
        }

        private static void Save(IAwardLogic logic)
        {
            Console.Clear();
            logic.Save();
            Console.Clear();
        }

        private static void Print(IUserLogic userLogic, IAwardLogic awardLogic)
        {
            var users = userLogic.GetAll();
            var awards = awardLogic.GetAll();

            int index = 0;
            foreach (var user in users)
            {
                Console.WriteLine($"Id = {index++}. {user.Name} {user.DateOfBirth.ToString("dd/MM/yyyy")}");
                Console.Write($"    Awards: ");
                foreach (var award in user.SetAwards)
                {
                    Console.Write($"{awards.ElementAt(award).Title} ");
                }

                Console.WriteLine();
            }
        }

        private static void Print(IAwardLogic logic)
        {
            var awards = logic.GetAll();

            int index = 0;
            foreach (var award in awards)
            {
                Console.WriteLine($"Id = {index++}. {award.Title}");
            }
        }
    }
}
