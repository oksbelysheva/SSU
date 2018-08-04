using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    class Biagram
    {
        private HashSet<String> arrayBiagram;
        private HashSet<String> arrayPairAlph;

        public HashSet<String> GetBiagramOpenText(String path)
        {
            arrayBiagram = new HashSet<string>();
            String openText = ReadOpenText(path);

            for (int i = 0; i < openText.Length-1; i++)
            {
                arrayBiagram.Add(openText.ElementAt(i).ToString() + openText.ElementAt(i + 1).ToString());
            }

            return arrayBiagram;
        }

        public HashSet<String> GetBiagramAlph(String path)
        {
            arrayPairAlph = new HashSet<string>();
            String openText = ReadAlph(path);

            for (int i = 0; i < openText.Length; i++)
            {
                for (int j = 0; j < openText.Length; j++)
                {
                    arrayPairAlph.Add(openText.ElementAt(i).ToString() + openText.ElementAt(j).ToString());
                }
            }
            return arrayPairAlph;
        }

        public String ReadOpenText(String path)
        {
            string text = String.Empty;
            using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                text = sr.ReadToEnd();
                text = text.ToLower();
            }
            string pattern = @"[\.,/}{)(\–:\+\\\*=\';""!?&]|\d|_|";
            text = Regex.Replace(text, pattern, "");
            pattern = @"[\t]|(\r\n\r)|\n|\s\s";
            text = Regex.Replace(text, pattern, " ");

            return text;
        }

        public String ReadAlph(String path)
        {
            string text = String.Empty;
            using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                text = sr.ReadToEnd();
                text = text.ToLower();
            }

            return text;
        }
    }
}
