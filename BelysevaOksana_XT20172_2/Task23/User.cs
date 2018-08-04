using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task23
{
    public class User
    {
        private string lastName, firstName, patronymicName;
        private DateTime dateBirthDay;

        public User(string lastName, string firstName, string patronymicName, DateTime dateBirthDay)
        {
            try
            {
                if (lastName.Length == 0 || firstName.Length == 0 || dateBirthDay > DateTime.Now)
                {
                    throw new Exception();
                }
                this.lastName = lastName;
                this.firstName = firstName;
                this.patronymicName = patronymicName;
                this.dateBirthDay = dateBirthDay;
            }
            catch
            {
                Console.WriteLine("Некорректные данные");
            }
        }

        public int Age
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                int age = dateNow.Year - this.dateBirthDay.Year;
                if (dateNow.Month < this.dateBirthDay.Month ||
                    (dateNow.Month == this.dateBirthDay.Month && dateNow.Day < this.dateBirthDay.Day)) age--;
                return age;
            }
        }

        public DateTime GetBirthDay()
        {
            return this.dateBirthDay;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public string GetPatronymicName()
        {
            return this.patronymicName;
        }

        public bool Correct()
        {
            return (this.firstName != null);
        }

        public override string ToString()
        {
            string res = string.Empty;
            if (this.Correct())
            res = string.Format("Имя: {1}{0}Фамилия: {2}{0}Отчество: {3}{0}Дата рождения: {4}{0}Возраст: {5}", Environment.NewLine, this.firstName, this.lastName, this.patronymicName, this.dateBirthDay.ToString(@"dd\/MM\/yyyy"), this.Age);
            return res;
        }
    }
}
