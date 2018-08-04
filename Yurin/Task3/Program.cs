using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите выполняему операцию:\n" +
                              "1. считать скрытую информацию\n" +
                              "2. скрыть информацию");
            Wav wav = new Wav();
            int choice = int.Parse(Console.ReadLine());
            String pathWav;
            String pathBin;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите путь к файлу со скрытой информацией");
                    pathWav = Console.ReadLine();
                    wav.ReadWav(pathWav);
                    break;
                case 2:
                    Console.WriteLine("Введите путь к скрываемой информацией");
                    pathBin = Console.ReadLine();
                    var bytes = File.ReadAllBytes(pathBin);
                    Console.WriteLine("Введите путь к файлу в котором требуется скрыть информацию");
                    pathWav = Console.ReadLine();
                    wav.AppendInfo(pathWav, pathBin);
                    break;
            }
            
        }
    }
}