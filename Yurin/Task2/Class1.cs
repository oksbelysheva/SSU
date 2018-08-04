using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полное имя файла:");
            String pathFile = Console.ReadLine();
            FileStream fileFileInfo = new FileStream(pathFile, FileMode.OpenOrCreate);

            string str = "4C4: 17";
            String position = str.Substring(0, str.IndexOf(":"));
            String byteReplace = str.Substring(str.IndexOf(" ") + 1);
            fileFileInfo.Position = Convert.ToInt32(position, 16);
            fileFileInfo.Seek(fileFileInfo.Position, SeekOrigin.Begin);
            int bit = fileFileInfo.ReadByte();
            if (bit != 22)
            {
                Console.WriteLine("Вы пытаеесь пропатчить не тот файл");
                fileFileInfo.Flush();
                fileFileInfo.Close();
                Console.Read();
                return;
            }
            fileFileInfo.Position = Convert.ToInt32(position, 16);
            fileFileInfo.WriteByte(byte.Parse(byteReplace, NumberStyles.AllowHexSpecifier));

            fileFileInfo.Flush();
            fileFileInfo.Close();

            Console.ReadKey();
        }
    }
}
