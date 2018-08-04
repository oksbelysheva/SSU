using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task24
{
    class MyString
    {
        private char[] str;

        public int Length
        {
            get
            {
                return str.Length;
            }
        }

        public char this[int index]
        {
            get
            {
                return str[index];
            }
            set
            {
                str[index] = value;
            }
        }

        public static MyString operator +(MyString s1, MyString s2)
        {
            int L = s1.str.Length + s2.str.Length;

            var sumstr = new MyString(L);

            for (int i = 0; i < s1.str.Length; i++)
            {
                sumstr[i] = s1[i];
            }
            for (int i = 0; i < s2.str.Length; i++)
            {
                sumstr[s1.str.Length + i] = s2[i];
            }
            return sumstr;
        }

        public static bool operator ==(MyString s1, MyString s2)
        {
            if (s1.str.Length != s2.str.Length)
            {
                return false;
            }
            for (int i = 0; i < s1.str.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(MyString s1, MyString s2)
        {
            return !(s1 == s2);
        }

        public static bool operator >(MyString s1, MyString s2)
        {
            if (s1.str.Length > s2.str.Length)
            {
                return true;
            }
            if (s1.str.Length < s2.str.Length)
            {
                return false;
            }
            int i = 0;
            while (s1[i] == s2[i])
                i++;
            return (s1[i] > s2[i]);
        }

        public static bool operator <(MyString s1, MyString s2)
        {
            if (s1.str.Length < s2.str.Length)
            {
                return true;
            }
            if (s1.str.Length > s2.str.Length)
            {
                return false;
            }
            int i = 0;
            while (s1[i] == s2[i])
                i++;
            return (s1[i] < s2[i]);
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MyString inputStr = obj as MyString;
            if ((System.Object)inputStr == null)
            {
                return false;
            }

            return (this == inputStr);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            MyString otherString = obj as MyString;
            if (otherString != null)
            {
                if (this > otherString) return 1;
                else if (this < otherString) return -1;
                else return 0;
            }
            else
                throw new ArgumentException("Объект сравнения не является объектом MyString");
        }

        public bool Contains(MyString containsString)
        {
            int i = Array.IndexOf(this.str, containsString[0], 0);
            do
            {
                if (containsString.Length > this.Length - i)
                    return false;
                 if (this.Substring(i, containsString.Length-1) == containsString)
                    return true;
            }
            while (i+1 < this.str.Length && (i = Array.IndexOf(this.str, containsString[0], i + 1)) != -1);
            return false;
        }

        public int IndexOf(MyString containsString)
        {
            int i = Array.IndexOf(this.str, containsString[0], 0);
            do
            {
                if (containsString.Length > this.Length - i)
                    return -1;
                if (this.Substring(i, containsString.Length) == containsString)
                    return i;
            }
            while (i + 1 < this.str.Length && (i = Array.IndexOf(this.str, containsString[0], i + 1)) != -1);
            return -1;
        }

        public int IndexOf(char containsSymbol)
        {
            return Array.IndexOf(this.str, containsSymbol);
        }

        public int LastIndexOf(MyString containsString)
        {
            int i = Array.IndexOf(this.str, containsString[0], 0);
            int j = -1;
            do
            {
                if (containsString.Length > this.Length - i)
                    return j;
                if (this.Substring(i, i + containsString.Length - 1) == containsString)
                    j = i;
            }
            while (i + 1 < this.str.Length && (i = Array.IndexOf(this.str, containsString[0], i + 1)) != -1);
            return j;
        }

        public MyString Substring(int start, int finish)
        {
            if (start < 0 || finish > this.Length)
                throw new Exception("Выход за пределы строки в Substring");
            char[] resStr = new char[finish-start+1];
            for (int i = 0; i <= finish - start; i++)
            {
                resStr[i] = this.str[start + i];
            }
            MyString res = ToMyString(resStr);
            return res;
        }

        public MyString Remove(int start, int count)
        {
            char[] resArray = new char[this.Length-count];
            int j = 0;
            for (int i = 0; i < this.Length; i++)
            {
                if (i < start || i > start + count)
                {
                    resArray[j] = this.str[i];
                    j++;
                }
            }
            return ToMyString(resArray);
        }

        public MyString Replace(char replaceSymbol,char newSymbol)
        {
            char[] resArray = new char[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                if (this.str[i] == replaceSymbol)
                {
                    resArray[i] = newSymbol;
                }
                else
                    resArray[i] = this.str[i];
            }
            return ToMyString(resArray);
        }

        public static char[] ToArray(MyString MyStr)
        {
            return MyStr.str;
        }

        public static MyString ToMyString(char[] arr)
        {
            MyString res = new MyString(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                res.str[i] = arr[i];
            }
            return res;
        }

        public override int GetHashCode()
        {
            var hashCode = 359211286;
            hashCode = hashCode * -1521134295 + EqualityComparer<char[]>.Default.GetHashCode(str);
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                sum += str[i];
            }
            hashCode = hashCode * -1521134295 + sum.GetHashCode();
            return hashCode;
        }

        public MyString(int init_size)
        {
            this.str = new char[init_size];
        }

        public MyString()
        {
            this.str = new char[0];
        }

        public override string ToString()
        {
            return new string(this.str);
        }

        public void ShowTest()
        {
            Console.WriteLine("Замена всех символов равные первому на A: {0}", (this.Replace(this.str[0], 'A')).ToString());
            Console.WriteLine("Удалить символы с 2го 4ый: {0}", (this.Remove(2, 4-2)).ToString());
            Console.WriteLine("Содержит ли строка \"lalala\": {0}", (this.Contains(MyString.ToMyString("lalala".ToArray()))));
            Console.WriteLine("Подстрока со 2го символа по 4ый: {0}", this.Substring(2, 4).ToString());
            Console.WriteLine("Последнее вхождение \"lalala\": {0}", this.LastIndexOf(MyString.ToMyString("lalala".ToArray())));
        }
    }
}
