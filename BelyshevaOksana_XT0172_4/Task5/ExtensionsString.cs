using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public static class ExtensionsString
    {
        public static bool IsDigit(this string str)
        {
            int pos = 0;
            if (str[0].CompareTo('+') == 0)
            {
                pos++;
            }

            bool existNotZero = false;
            for (int i = pos; i < str.Length; i++)
            {
                if (!char.IsDigit(str, i))
                {
                    return false;
                }

                if (str[i] != '0')
                {
                    existNotZero = true;
                }
            }

            return existNotZero;
        }
    }
}
