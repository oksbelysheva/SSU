using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Table
    {
        private int Size { get; set; }
        public string[] table { get; set; }

        public static int ReadParametrN()
        {
            try
            {
                using (StreamReader sr = new StreamReader("n.txt"))
                {
                    string line = sr.ReadLine();
                    line.Trim();
                    return int.Parse(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: n.txt");
                Console.WriteLine(e.Message);
                return -1;
            }

        }
        private string ReadCryptogram()
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

        private string[] ReadBiaram()
        {
            List<String> biagrams = new List<String>();
            try
            {
                using (StreamReader sr = new StreamReader("notExistBiagram.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        biagrams.Add(line);
                    }
                    return biagrams.ToArray();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: notExistBiagram.txt");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Table()
        {
            this.Size = ReadParametrN();
            String crypt = ReadCryptogram();
            string[] biagram = ReadBiaram();

            string[] column = new string[this.Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < crypt.Length; j+=Size)
                {
                    column[i] = column[i] + crypt[j];
                }
            }

            table = new string[Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (j == i)
                    {
                        table[i] = table[i] + "-";
                        continue;
                    } 
                    bool isExistBiagram = false;
                    for (int k = 0; k < Math.Min(column[i].Length, column[j].Length); k++)
                    {
                        String temp = column[i].ElementAt(k).ToString() + column[j].ElementAt(k).ToString();
                        temp = temp.ToLower();
                        if (biagram.Contains(temp))
                        {
                            isExistBiagram = true;
                            Console.WriteLine((i+1) + " " + (j+1)+ " " + (k+1) + " " + temp);
                            break;
                        }
                    }

                    if (isExistBiagram)
                        table[i] = table[i] + "-";
                    else
                    {
                        table[i] = table[i] + "+";
                    }
                }
            }

            printTable(table);
        }

        public Table(String path)
        {
            List<string> tempTable = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        tempTable.Add(line);
                    }
                }

                table = tempTable.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+path);
                Console.WriteLine(e.Message);
            }
        }

        private void printTable(string[] table)
        {
            using (StreamWriter sw = new StreamWriter("table.txt"))
            {
                foreach (var temp in table)
                {
                    sw.WriteLine(temp);
                } 
            }
        }
    }
}
