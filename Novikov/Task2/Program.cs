using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static int n;
        static string input1, input2, alphabet, key, text, firstFile, secondFile;
        static void Main(string[] args)
        {
            Console.WriteLine("0 - Сгенирировать случайный текст");
            Console.WriteLine("1 - Вычислить индекс совпадения");
            Console.WriteLine("2 - Вычислить средний индекс совпадения");
            Console.WriteLine("3 - Шифр Виженера");
            Console.WriteLine("4 - Подсчитать индекс совпадения для шифра Виженера");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    {
                        Console.WriteLine("Введите длину");
                        int length = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите путь к файлу с алфавитом");
                        string alph = Console.ReadLine();
                        Console.WriteLine("Введите путь к файлу для записи");
                        string path = Console.ReadLine();
                        GeneratorRandomSimbol(length, alph, path);
                        break;
                    }
                case 1:
                    {
                        ReadFile();
                        n = Math.Min(input1.Length, input2.Length);
                        Console.WriteLine($"Индекс совпадения = {GetIndex()}");
                        break;
                    }
                case 2:
                    {
                        ReadFile();
                        n = Math.Min(input1.Length, input2.Length);
                        Console.WriteLine($"Средний индекс совпадения = {Average()}");
                        break;
                    }
                case 3:
                    {
                        ReadAlphabet();
                        GetKey();
                        ReadText();
                        Console.WriteLine("1 - Зашифровать");
                        Console.WriteLine("2 - Расшифровать");
                        int idx = int.Parse(Console.ReadLine());

                        switch (idx)
                        {
                            case 1:
                                {
                                    Encode();
                                    break;
                                }
                            case 2:
                                {
                                    Decode();
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                case 4:
                    {
                        ReadText();
                        n = input1.Length;
                        GetIndexForVigener();
                        break;
                    }
                default:
                    break;
            }
        }

        private static void GeneratorRandomSimbol(int length, string alph, string path)
        {
            Random r = new Random();

            string eng = File.ReadAllText(alph, Encoding.Default);

            using (StreamWriter wr = new StreamWriter(File.Create(path), Encoding.Default))
            {
                for (int i = 0; i < length; i++)
                {
                    wr.Write(eng[r.Next(0, eng.Length)]);
                }
            }
        }

        private static void ReadFile()
        {
            Console.WriteLine("Введите имя первого входного файла");
            string firstFile = Console.ReadLine();
            Console.WriteLine("Введите имя второго входного файла");
            string secondFile = Console.ReadLine();
            input1 = File.ReadAllText(firstFile, Encoding.Default);
            input1 = System.Text.RegularExpressions.Regex.Replace(input1, @"['\.!,\s:;?\]\[\}\{\)\(«» \n\d]", "").ToLower();
            input2 = File.ReadAllText(secondFile, Encoding.Default);
            input2 = System.Text.RegularExpressions.Regex.Replace(input2, @"['\.!,\s:;?\]\[\}\{\)\(«» \n\d]", "").ToLower();
        } 

        private static double GetIndex()
        {
            int delta = 0;
            for (int i = 0; i < n; i++)
            {
                if (input1[i] == input2[i])
                {
                    delta++;
                }
            }
            return (double)delta / n;
        }

        private static double Average()
        {

            Dictionary<char, int> dictionaryY = new Dictionary<char, int>();
            Dictionary<char, int> dictionaryZ = new Dictionary<char, int>();

            for (int i = 0; i < n; i++)
            {
                if (!dictionaryY.ContainsKey(input1[i]))
                {
                    dictionaryY[input1[i]] = 1;
                }
                else
                {
                    dictionaryY[input1[i]]++;
                }

                if (!dictionaryZ.ContainsKey(input1[i]))
                {
                    dictionaryZ[input1[i]] = 1;
                }
                else
                {
                    dictionaryZ[input1[i]]++;
                }
            }

            double averageIndex = 0;

            foreach (var item in dictionaryY)
            {
                dictionaryZ[item.Key] *= item.Value;
            }

            foreach (var item in dictionaryZ)
            {
                averageIndex += item.Value;
            }

            return (double)(averageIndex / (n * n));
        }

        private static void ReadAlphabet()
        {
            alphabet = File.ReadAllText("alph.txt", Encoding.Default).ToLower();
        }

        private static void GetKey()
        {
            key = File.ReadAllText("key.txt", Encoding.Default).ToLower();
        }

        private static void ReadText()
        {
            Console.WriteLine("Введите имя входного файла");
            firstFile = Console.ReadLine();

            input1 = File.ReadAllText(firstFile, Encoding.Default);
            input1 = System.Text.RegularExpressions.Regex.Replace(input1, @"['\.!,\s:;?\]\[\}\{\)\(«» \n\d]", "").ToLower();
        }

        private static string Shift(string row, int l)
        {
            string result = string.Empty;
            for (int i = 0; i < row.Length; i++)
            {
                result += row[(i + l) % row.Length];
            }

            return result;
        }

        private static void GetIndexForVigener()
        {
            for (int i = 1; i < 16; i++)
            {
                input2 = Shift(input1, i);
                Console.WriteLine("Для l = {0} индекс равен {1}", i, GetIndex());
            }
        }

        private static void Encode()
        {
            int count = 0;
            using (StreamWriter stream = new StreamWriter(File.Open("encode_" + firstFile, FileMode.Create, FileAccess.ReadWrite), Encoding.Default))
            {
                while (input1.Length > count)
                {
                    stream.Write(alphabet[(alphabet.IndexOf(input1[count]) + alphabet.IndexOf(key[count % key.Length])) % alphabet.Length]);
                    count++;
                }
            }

            ReadEncodeText();
        }

        private static void ReadEncodeText()
        {
            input1 = File.ReadAllText("encode_" + firstFile, Encoding.Default);

            n = input1.Length;
            for (int i = 1; i < 16; i++)
            {
                input2 = Shift(input1, i);
                Console.WriteLine("Для l = {0} индекс равен {1}", i, GetIndex());
            }

        }

        private static void Decode()
        {
            text = File.ReadAllText(firstFile, Encoding.Default);
            int count = 0;
            using (StreamWriter stream = new StreamWriter(File.Open(firstFile.Replace("encode", "decode"), FileMode.Create, FileAccess.ReadWrite), Encoding.Default))
            {
                while (text.Length > count)
                {
                    stream.Write(alphabet[(alphabet.IndexOf(text[count]) + (alphabet.Length - alphabet.IndexOf(key[count % key.Length]))) % alphabet.Length]);
                    count++;
                }
            }
        }
    }
}
