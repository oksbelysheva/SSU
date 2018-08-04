using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите фамилию: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите имя: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите отчество, если оно есть: ");
            string patronymicName = Console.ReadLine();

            Console.Write("Введите дату рождения в формате дд/мм/гггг: ");
            DateTime dateBirthDay = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите должность: ");
            string positionJob = Console.ReadLine();

            Console.WriteLine("Введите стаж работы гг мм дд: ");
            string expirence = Console.ReadLine();
            string[] arrayExp = expirence.Split();
            Experience experienceJob = new Experience(int.Parse(arrayExp[0]), int.Parse(arrayExp[1]), int.Parse(arrayExp[2]));

            Employee employee = new Employee(lastName, firstName, patronymicName, dateBirthDay, experienceJob, positionJob);
            Console.WriteLine(employee.ToString());
        }
    }
}
