using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задачи:\n" +
                              "1 - Вычисление множества запретных биграмм языка открытых сообщений (text.txt)\n" +
                              "2 - Создание перестановки текста (message.txt) по ключу (key.txt) длины n (n.txt)\n" +
                              "3 - Построение вспомогательной таблицы для анализа шифра перестановки при известной длине периода (n.txt)\n" +
                              "4 - Построение ориентированного дерева возможных перестановок (anticipatedKey.txt)\n" +
                              "5 - Перебор ключей по ориентированному лесу возможных перестановок (decipher.txt) ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                {
                    Biagram biagram = new Biagram();
                    HashSet<String> existBiagram = biagram.GetBiagramOpenText("text.txt");
                    HashSet<String> alphBiagram = biagram.GetBiagramAlph("alph.txt");
                    String[] existArray = existBiagram.ToArray();
                    String[] alphArray = alphBiagram.ToArray();
                    IEnumerable<String> notExist = alphArray.Except(existArray);
                    using (StreamWriter sw = File.AppendText("notExistBiagram.txt"))
                    {
                        foreach (var temp in notExist)
                        {
                            sw.WriteLine(temp);
                        }
                    }
                        break;
                }
                case 2:
                {
                        GenerateMonocyclicTransposition transposition = new GenerateMonocyclicTransposition();
                        Cryptogram cryptogram = new Cryptogram();
                        break;
                }
                case 3:
                {
                    Table table = new Table();
                    break;
                }
                case 4:
                {
                    Table table = new Table("table.txt");
                    CreateInpossibleTransposition(table);
                    break;
                }
                case 5:
                {
                    List<int[]> key = ReadKey("anticipatedKey.txt");
                    Decipher(key);
                    break;
                }

                default:
                    break;
            }

        }

        private static void CreateInpossibleTransposition(Table table)
        {
            string[] strTable = table.table;
            List<String> result = new List<String>();

            int[] countPlusInColumn = new int[strTable[0].Length];
            for (int i = 0; i < strTable[0].Length; i++)
            {
                for (int j = 0; j < strTable[0].Length; j++)
                {
                    if (strTable[i].ElementAt(j).Equals('+'))
                    {
                        countPlusInColumn[j]++;
                    }
                }
            }

            int minCount = 100000;
            int posMinCount = -1;
            for (int i = 0; i < countPlusInColumn.Length; i++)
            {
                if (countPlusInColumn[i] < minCount)
                {
                    minCount = countPlusInColumn[i];
                    posMinCount = i;
                }
            }

            for (int i = 0; i < countPlusInColumn.Length; i++)
            {
                if (countPlusInColumn[i] == minCount)
                {
                    if (minCount == 0)
                    {
                        result.Add(" "+(i + 1).ToString()+" ");
                    }
                    else
                    {
                            for (int j = 0; j < strTable[0].Length; j++)
                            {
                                if (strTable[i].ElementAt(j).Equals('+'))
                                {
                                result.Add(" "+(i + 1).ToString() + " " + (j + 1).ToString()+" ");
                                }
                            }
                    }
                }
            }

            List<Tuple<int, int>> pairList = new List<Tuple<int, int>>();

            for (int i = 0; i < strTable[0].Length; i++)
            {
                for (int j = 0; j < strTable[0].Length; j++)
                {
                    if (strTable[i].ElementAt(j).Equals('+'))
                    {
                        pairList.Add(new Tuple<int, int>(i+1,j+1));
                    }
                }
            }

            bool flag = true;
            while (flag)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 0; j < pairList.Count; j++)
                    {
                        Tuple<int, int> tempPair = pairList[j];
                        if (result[i].Contains(" "+tempPair.Item1.ToString()+" ") && (!result[i].Contains(" "+tempPair.Item2.ToString()+" ")))
                        {
                            if (result[i].EndsWith(" "+tempPair.Item1.ToString()+" ", StringComparison.Ordinal))
                            {
                                String tempString = result[i] + tempPair.Item2.ToString()+ " ";
                                //int flagContains = -1;
                                /*for (int k = 0; k < result.Count; k++)
                                {
                                    if (result[k].IndexOf(tempString)!=-1)
                                    {
                                        flagContains = k;
                                    }
                                }*/

                                /*if (flagContains == -1)
                                {*/
                                //if (tempString.Length > result[i].Length)
                                //{
                                    result.Add(tempString);
                                //}
                                /*}*/
                            }
                            /*else
                            {
                                String tempString = result[i].Replace(
                                    result[i].Substring(result[i].IndexOf(" "+tempPair.Item1.ToString()+" ",0, StringComparison.Ordinal)),
                                    " "+tempPair.Item1.ToString()+" "+tempPair.Item2.ToString()+" ");
                                //int flagContains = -1;
                                //for (int k = 0; k < result.Count; k++)
                                //{
                                //    if (result[k].IndexOf(tempString)!=-1)
                                //    {
                                //        flagContains = k;
                                //    }
                                //}

                                //if (flagContains == -1)
                                //{
                                if (tempString.Length > result[i].Length)
                                {
                                    result.Add(tempString);
                                }
                                //}
                            }*/
                        }

                        else

                        if (result[i].Contains(" "+tempPair.Item2.ToString()+" ") && !result[i].Contains(" " + tempPair.Item1.ToString()+" "))
                        {
                            if (result[i].IndexOf(" " + tempPair.Item2.ToString() + " ", 0, StringComparison.Ordinal)==0)
                            {
                                String tempString = " "+tempPair.Item1.ToString() + result[i].ToString();
                                //int flagContains = -1;
                                //for (int k = 0; k < result.Count; k++)
                                //{
                                //    if (result[k].IndexOf(tempString)!=-1)
                                //    {
                                //        flagContains = k;
                                //    }
                                //}

                                //if (flagContains == -1)
                                //{
                                //if (tempString.Length > result[i].Length)
                                //{
                                    result.Add(tempString);
                                //}
                                //}
                            }
                            /*else
                            {
                                int pos = result[i].IndexOf(" "+tempPair.Item2.ToString() + " ", 0, StringComparison.Ordinal);
                                String tempString = result[i].Replace(
                                    result[i].Substring(0,pos),
                                    " "+tempPair.Item1.ToString());
                                //int flagContains = -1;
                                //for (int k = 0; k < result.Count; k++)
                                //{
                                //    if (result[k].IndexOf(tempString)!=-1)
                                //    {
                                //        flagContains = k;
                                //    }
                                //}

                                //if (flagContains == -1)
                                //{
                                if (tempString.Length > result[i].Length)
                                {
                                    result.Add(tempString);
                                }
                                //}
                            }*/
                        }
                    }
                    if (CountWord(result[i]) == countPlusInColumn.Length)
                    {
                        flag = false;
                    }
                    else
                    {
                        result.RemoveAt(i);
                        i--;
                        HashSet<String> deleteRepeat = new HashSet<String>(result.ToArray());
                        result = new List<String>(deleteRepeat);
                    }
                   
                }
            }

            using (StreamWriter sw = new StreamWriter("anticipatedKey.txt"))
            {
                foreach (var temp in result)
                {
                        sw.Write(temp.ToString());
                        sw.WriteLine();
                }
            }
            
        }

        private static int CountWord(String str)
        {
            return str.Trim().Split().Length;
        }

        private static bool isAllCreate(List<String> list, int length)
        {
            foreach (var temp in list)
            {
                if (temp.Length != length)
                    return false;
            }

            return true;
        }

        private static List<int[]> ReadKey(String path)
        {
            try
            {
                using (StreamReader sr = new StreamReader("anticipatedKey.txt"))
                {
                    List<int[]> arrayKey = new List<int[]>();
                    while (!sr.EndOfStream)
                    {
                        String[] currentKeyString = sr.ReadLine().Trim().Split();
                        int[] currentKey = new int[currentKeyString.Length];
                        for (int i = 0; i < currentKey.Length; i++)
                        {
                            currentKey[i] = int.Parse(currentKeyString[i]);
                        }
                        arrayKey.Add(currentKey);
                    }

                    return arrayKey;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+path);
                return null;
            }
            
        }

        private static string ReadCryptogram()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader("cryptogram.txt", Encoding.GetEncoding(1251)))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        stringBuilder.Append(line);
                    }
                    return stringBuilder.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: cryptogram.txt");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void Decipher(List<int[]> key)
        {
            if (key == null)
            {
                Console.WriteLine("Error: anticipatedKey.txt");
                return;
            }
            String cryptogram = ReadCryptogram();
            if (cryptogram == null)
            {
                Console.WriteLine("Error: cryptogram.txt");
                return;
            }

            StringBuilder AllDecipher = new StringBuilder();
            for (int i = 0; i < key.Count; i++)
            {
                StringBuilder decipher = new StringBuilder();
                int[] tempKey = key[i];
                int position = 0;
                while (position < cryptogram.Length)
                {
                    String partCryptogram = cryptogram.Substring(position, tempKey.Length);
                    char[] temp = new char[tempKey.Length];
                    for (int j = 0; j < tempKey.Length; j++)
                    {
                        temp[j] = partCryptogram[tempKey[j] - 1];
                    }
                    decipher.Append(temp);
                    position += tempKey.Length;
                }
                AllDecipher.Append(decipher);
                AllDecipher.AppendLine();
            }
            PrintDecipher(AllDecipher.ToString());
        }

        private static void PrintDecipher(String message)
        {
            File.WriteAllText("allDecipher.txt", message);
        }
    }
}
