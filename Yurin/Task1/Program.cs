using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Management;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace Task1
{
    class Program
    {
        static FileInfo fi = new FileInfo(Process.GetCurrentProcess().MainModule.FileName);
        static String nameFile = fi.Name;
        public static string S2 = "B\0e\0g\0i\0e\0S\0e\0a\0c\0h\0e\0r\0q\0q\0q\0";
        public static string S = "BegieSeacherqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq";

        private static void Main(string[] args)
        {
            List<HardDrive> hddCollection = GetInfoHDD();
            if (FindPosition(nameFile) != -1)
            {
                RunExe();
                Item(hddCollection);
                CreatBatFile();
            }
            else
            {
                if (CheckHard(hddCollection))
                {
                    Console.WriteLine("Application is working");
                    Console.Read();
                }
            }
        }
        private static void CreatBatFile()
        {
            using (FileStream fstream = new FileStream(@"batFile.bat", FileMode.OpenOrCreate))
            {
                string[] words = new string[5];
                words[0] = "ping -n 1 -w 500 127.0.0.1 >nul" + Environment.NewLine;
                words[1] = "del "+nameFile+" /q /s" + Environment.NewLine;
                words[2] = "ren Temp.exe " + nameFile + Environment.NewLine;
                words[3] = "start " + nameFile + Environment.NewLine;
                words[4] = "del %0";

                foreach (string item in words)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(item);
                    fstream.Write(array, 0, array.Length);
                }
            }

            Process.Start(@"batFile.bat");
        }
        private static void Item(List<HardDrive> hddCollection)
        {
            int peek = FindPosition();

            string row = hddCollection[0].Model + '@' + hddCollection[0].SerialNo;
            byte[] masByte = GetRowByte(row);

            using (var writer = new BinaryWriter(File.Open("Temp.exe", FileMode.Open, FileAccess.Write), Encoding.Default))
            {
                writer.Seek(peek, SeekOrigin.Begin);
                writer.Write(masByte, 0, masByte.Length);
            }
        }
        private static bool CheckHard(List<HardDrive> hddCollection)
        {
            for (int i = S.Length - 1; i >= 0; i--)
            {
                if (S[i] == 'q')
                    S = S.Remove(i);
            }

            string[] ss = S.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            if (ss[0] == hddCollection[0].Model && ss[1] == hddCollection[0].SerialNo)
                return true;
            else
            {
                return true;
            }
        }
        private static byte[] GetRowByte(string row)
        {
            char[] masChar = row.Normalize().ToCharArray();
            byte[] masByte = new byte[masChar.Length * 2];
            int k = 0;
            for (int i = 0; i < masChar.Length; i++)
            {
                masByte[k++] = (byte)masChar[i];
                masByte[k++] = 0;
            }
            return masByte;
        }
        private static void RunExe()
        {
            if (File.Exists("Temp.exe"))
                File.Delete("Temp.exe");
            File.Copy(nameFile, "Temp.exe");
        }
        private static int FindPosition(string name = "Temp.exe")
        {
            using (StreamReader read = new StreamReader(File.Open(name, FileMode.Open, FileAccess.Read, FileShare.Read), Encoding.Default))
            {
                string row = read.ReadToEnd();
                return row.IndexOf(S2);
            }
        }
        private static string GetNameDisk(ManagementObject drive)
        {
            foreach (ManagementObject partition in
            new ManagementObjectSearcher(
                "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"]
                  + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
            {
                foreach (ManagementObject disk in
             new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                      + partition["DeviceID"]
                      + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                {
                    return disk["Name"].ToString().Trim();
                }
            }
            return null;
        }
        private static List<HardDrive> GetInfoHDD()
        {
            string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            BaseDirectory = (BaseDirectory.Remove(BaseDirectory.IndexOf("\\")));

            ManagementObjectSearcher searcher = new
                      ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            List<HardDrive> hdCollection = new List<HardDrive>();
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                hd.Model = wmi_HD["Model"].ToString();
                if (hd.Model.Contains("Reader USB Device"))
                    continue;
                hd.SerialNo = wmi_HD["SerialNumber"].ToString().Trim();

                hd.Directory = GetNameDisk(wmi_HD);

                if (hd.Directory == BaseDirectory)
                    hdCollection.Add(hd);
            }
            return hdCollection;
        }
        public class HardDrive
        {
            public string Model { get; set; }
            public string SerialNo { get; set; }
            public string Directory { get; set; }
            public override string ToString()
            {
                return string.Format($"Model: {Model}\nSerialNomber: {SerialNo}\n\nDirectory: {Directory}");
            }
        }
    }
}