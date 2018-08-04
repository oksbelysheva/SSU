//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Task2
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Введите полное имя файла:");
//            String pathFile = Console.ReadLine();
//            String pathPatch = pathFile.Substring(0, pathFile.LastIndexOf("\\") + 1) + "patch.exe";
//            var fileStream = new FileStream(pathFile, FileMode.Open);
//            FileInfo pathFileInfo = new FileInfo(pathPatch);
//            var patchStream = pathFileInfo.Create();

//            fileStream.CopyTo(patchStream);

//            string[] readReplaceByte = File.ReadAllLines("ByteReplace.txt");
//            foreach (var str in readReplaceByte)
//            {
//                String position = str.Substring(0, str.IndexOf(":"));
//                String byteReplace = str.Substring(str.IndexOf(" ") + 1);
//                patchStream.Position = Convert.ToInt32(position, 16);
//                patchStream.WriteByte(byte.Parse(byteReplace, NumberStyles.AllowHexSpecifier));
//            }
            
//            fileStream.Close();
            
//            patchStream.Flush();
//            patchStream.Close();
//            Console.ReadKey();
//        }

//        //Переводит шестнадцатиричное символьное представление в число byte
//        static byte StrToByte(string s)
//        {
//            return (byte)(LitToByte(s[0]) * 16 + LitToByte(s[1]));
//        }

//        //Переводит шестнадцатиричный символ в число byte
//        static byte LitToByte(char s)
//        {
//            const string z = "0123456789abcdef";
//            return (byte)z.IndexOf(s);
//        }
//    }
//}
