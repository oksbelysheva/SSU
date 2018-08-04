using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    class FrequencyTable
    {
        private string openText;
        private string alphabet;
        private Dictionary<char, int> table = new Dictionary<char, int>();

        public FrequencyTable()
        {
            ReadAlphabet();
            ReadMessage();
            foreach (var letter in alphabet)
            {
                table.Add(letter, 0);
            }

            foreach (var letter in openText)
            {
                if (table.Keys.Contains(letter))
                {
                    table[letter] = table[letter] + 1;
                }
            }


            using (StreamWriter stream = new StreamWriter(File.Open("tableFrequency.txt", FileMode.Create, FileAccess.ReadWrite), Encoding.Default))
            {
                foreach (var pairLetterCount in table.OrderByDescending(x => x.Value))
                {
                    double freq = (double)pairLetterCount.Value / openText.Length;
                    stream.WriteLine("{0} {1:0.00000}", pairLetterCount.Key, freq);
                }
            }
        }

        private void ReadMessage()
        {
            openText = File.ReadAllText("textForComputeFrequency.txt", Encoding.Default);
            if (alphabet.Contains("о")|| alphabet.Contains("а")|| alphabet.Contains("е"))
            {
                Regex rgx = new Regex("[^а-яА-Я]");
                openText = rgx.Replace(openText, "").ToLower();
            }
            else
            {
                Regex rgx = new Regex("[^a-zA-Z]");
                openText = rgx.Replace(openText, "").ToLower();
            }
            
        }

        private void ReadAlphabet()
        {
            alphabet = File.ReadAllText("alph.txt", Encoding.Default).ToLower();
        }
    }
}
