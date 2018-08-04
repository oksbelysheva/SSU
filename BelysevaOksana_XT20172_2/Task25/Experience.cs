using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25
{
    class Experience
    {
        private int year;
        private int month;
        private int day;

        public Experience(int year, int month, int day)
        {
            if (year < 0 || month > 11 || day > 30 || day < 0 || month < 0)
            {
                throw new Exception("Ошибка при вводе стажа работы");
            }
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public int getYear()
        {
            return this.year;
        }

        public int getMonth()
        {
            return this.month;
        }

        public int getDay()
        {
            return this.day;
        }

        public string toString()
        {
            return this.year + " лет " + this.month + " месяцев " + this.day +" дней ";
        }
    }
}
