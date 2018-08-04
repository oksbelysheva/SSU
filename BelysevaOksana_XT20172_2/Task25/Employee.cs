using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task23;

namespace Task25
{
    class Employee : User
    {
        private Experience workExperience;
        string jobPosition;

        public Employee(string lastName, string firstName, string patronymicName, DateTime dateBirthDay, Experience expirience, string pos) : base(lastName, firstName, patronymicName, dateBirthDay)
        {
            if (expirience.getYear() > this.Age || (expirience.getYear() == this.Age && expirience.getMonth()>this.GetBirthDay().Month)
                || (expirience.getYear() == this.Age && expirience.getMonth() == this.GetBirthDay().Month && expirience.getDay() > this.GetBirthDay().Day))
                throw new Exception("Ошибка: стаж работы больше возраста");
            this.workExperience = expirience;
            this.jobPosition = pos;
        }

        public new string ToString()
        {
            string res = "";
            if (this.Correct())
                res = String.Format("Имя: {1}{0}Фамилия: {2}{0}Отчество: {3}{0}Дата рождения: {4}{0}Возраст: {5}{0}Должность: {6}{0}Стаж работы: {7}", Environment.NewLine, this.GetFirstName(), this.GetLastName(), this.GetPatronymicName(), this.GetBirthDay().ToString(@"dd\/MM\/yyyy"), this.Age, this.jobPosition, this.workExperience.toString());
            return res;
        }
    }
}
