using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Vigenere
    {
        private string openText;
        private string cryptText;
        private string key;
        private string alphabet;
        

        public Vigenere()
        {
            ReadAlphabet();
            GetKey();
        }

        public void DecodeWithoutKey()
        {
            ReadCrypt();

        }


        public void Encode()
        {
            ReadMessage();
            int count = 0;
            using (StreamWriter stream = new StreamWriter(File.Open("encode.txt", FileMode.Create, FileAccess.ReadWrite), Encoding.Default))
            {
                while (openText.Length > count)
                {
                    stream.Write(alphabet[(alphabet.IndexOf(openText[count]) + alphabet.IndexOf(key[count % key.Length])) % alphabet.Length]);
                    count++;
                }
            }
        }

        public void Decode()
        {
            ReadCrypt();
            int count = 0;
            using (StreamWriter stream = new StreamWriter(File.Open("decode.txt", FileMode.Create, FileAccess.ReadWrite), Encoding.Default))
            {
                while (cryptText.Length > count)
                {
                    stream.Write(alphabet[(alphabet.IndexOf(cryptText[count]) + (alphabet.Length - alphabet.IndexOf(key[count % key.Length]))) % alphabet.Length]);
                    count++;
                }
            }
        }

        private void ReadMessage()
        {
            openText = File.ReadAllText("message.txt", Encoding.Default);
            openText = System.Text.RegularExpressions.Regex.Replace(openText, @"['—\.!,\s:;?\]\[\}\{\)\(«» \n\d]", "").ToLower();
        }

        private void ReadCrypt()
        {
            cryptText = File.ReadAllText("encode.txt", Encoding.Default);
            cryptText = System.Text.RegularExpressions.Regex.Replace(cryptText, @"['—\.!,\s:;?\]\[\}\{\)\(«» \n\d]", "").ToLower();
        }

        private void ReadAlphabet()
        {
            alphabet = File.ReadAllText("alph.txt", Encoding.Default).ToLower();
        }

        private void GetKey()
        {
            key = File.ReadAllText("key.txt", Encoding.Default).ToLower();
            using (StreamWriter stream = new StreamWriter(File.Open("keyLength.txt", FileMode.Create, FileAccess.ReadWrite), Encoding.Default))
            {
                stream.Write(key.Length);
            }
        }
    }
}
