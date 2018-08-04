using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            start:
            Console.WriteLine("Enter 1 to start the monitoring mode");
            Console.WriteLine("Enter 2 to start backup mode");
            int mode = int.Parse(Console.ReadLine());
            switch (mode)
            {
                case 1:
                    {
                        MonitorFolder monitorFolder = new MonitorFolder();
                        monitorFolder.Run();
                        monitorFolder.Stop();
                        Console.Clear();
                        goto start;
                    }

                case 2:
                    {
                        Backup backup = new Backup();
                        backup.Run();
                        Console.Clear();
                        goto start;
                    }
            }
        }
    }
}
