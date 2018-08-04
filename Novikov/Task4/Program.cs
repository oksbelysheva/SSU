using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задачи:\n" +
                              "0 - Шифр Виженера\n" +
                              "1 - Атака по частотному анализу\n" +
                              "2 - Атака по вероятному слову\n");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    {
                        Console.WriteLine("Введите номер задачи:\n" +
                              "1 - Зашифровать message.txt с ключом key.txt\n" +
                              "2 - Расшифровать encode.txt с ключом key.txt\n");
                        int choice2 = int.Parse(Console.ReadLine());
                        switch(choice2)
                        {
                            case 1:
                                {
                                    Vigenere vigenere = new Vigenere();
                                    vigenere.Encode();
                                    break;
                                }
                            case 2:
                                {
                                    Vigenere vigenere = new Vigenere();
                                    vigenere.Decode();
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Введите номер задачи:\n" +
                              "1 - Вычисление таблицы частот языка открытого сообщения textForComputeFrequency.txt\n" +
                              "2 - Вычисление ключа Виженера при известной длине ключа keyLength.txt\n");
                        int choice2 = int.Parse(Console.ReadLine());
                        switch (choice2)
                        {
                            case 1:
                                {
                                    FrequencyTable frequencyTable = new FrequencyTable();
                                    break;
                                }
                            case 2:
                                {
                                    Vigenere vigenere = new Vigenere();
                                    vigenere.DecodeWithoutKey();
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case 2:
                    {

                        break;
                    }

                default:
                    Console.WriteLine("Команды "+choice+" не существует");
                    break;
            }
        }
    }
}
