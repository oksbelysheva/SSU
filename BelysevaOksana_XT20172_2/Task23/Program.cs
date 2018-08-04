using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите фамилию: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите имя: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите отчество, если оно есть: ");
            string patronymicName = Console.ReadLine();

            Console.Write("Введите дату рождения в формате дд/мм/гггг: ");
            DateTime dateBirthDay = DateTime.Parse(Console.ReadLine());

            User user = new User(lastName, firstName, patronymicName, dateBirthDay);
            Console.WriteLine(user.ToString());
        }
    }
}
