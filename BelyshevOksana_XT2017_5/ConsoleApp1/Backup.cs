using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Backup
    {
        private string pathFileLog;
        private string pathDirMonitor;
        private string pathDirBackups;
        private List<NoteLog> log = new List<NoteLog>();

        public Backup()
        {
            string pathMonitor = ConfigurationManager.AppSettings["folder"];

            DirectoryInfo dirMonitor = new DirectoryInfo(pathMonitor);
            if (!dirMonitor.Exists)
            {
                throw new FileNotFoundException("pathMonitor doesn't exist");
            }

            DirectoryInfo dirBackups = new DirectoryInfo(Path.Combine(dirMonitor.Parent.FullName.ToString(), "Backups"));
            if (!dirBackups.Exists)
            {
                throw new FileNotFoundException("pathBackup doesn't exist");
            }

            FileInfo fileLog = new FileInfo(Path.Combine(dirMonitor.Parent.FullName.ToString(), "Log.txt"));
            if (!fileLog.Exists)
            {
                throw new FileNotFoundException("fileLog doesn't exist");
            }

            this.pathDirBackups = dirBackups.FullName;
            this.pathDirMonitor = dirMonitor.FullName;
            this.pathFileLog = fileLog.FullName;
        }

        public void Run()
        {
            this.ReadLog();
            this.ShowUser();
            Console.WriteLine("Enter number backup:");
            int number = int.Parse(Console.ReadLine());
            this.DoBackup(number);

            Console.WriteLine("Enter E to exit");
            while (Console.ReadLine() != "e" && Console.ReadLine() != "E")
            {
            }
        }

        private void ReadLog()
        {
            this.log.Add(new NoteLog());
            using (StreamReader sr = new StreamReader(this.pathFileLog))
            {
                while (sr.Peek() >= 0)
                {
                    this.log.Add(new NoteLog(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine()));
                }
            }
        }

        private void ShowUser()
        {
            Console.WriteLine("0 before");
            for (int i = 1; i < this.log.Count; i++)
            {
                Console.WriteLine($"{i} {log[i].DateLog} : {log[i].BeforeLog} {log[i].TypeLog}");
            }
        }

        private void DoBackup(int number)
        {
            for (int i = this.log.Count - 1; i > number; i--)
            {
                string tempType = this.log[i].TypeLog;
                switch (tempType)
                {
                    case "renamed":
                        {
                            this.BackRenamed(i);
                            break;
                        }

                    case "created":
                        {
                            this.BackCreated(i);
                            break;
                        }

                    case "created with data":
                        {
                            this.BackCreated(i);
                            break;
                        }

                    case "deleted":
                        {
                            this.BackDeleted(i);
                            break;
                        }

                    case "changed":
                        {
                            this.BackChanged(i);
                            break;
                        }
                }
            }

            this.RemoveStringInBackup(number);
        }

        private void RemoveStringInBackup(int number)
        {
            string[] readText = System.IO.File.ReadAllLines(this.pathFileLog);
            File.Delete(this.pathFileLog);
            FileInfo fileLog = new FileInfo(this.pathFileLog);
            FileStream fs = fileLog.Create();
            fs.Close();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.pathFileLog, false))
            {
                for (int i = 0; i < number * 4; i++)
                {
                        file.WriteLine(readText[i]);
                }

                file.Close();
            }
        }

        private void BackChanged(int i)
        {
            int number = i;
            for (int j = number - 1; j >= 0; j--)
            {
                if (this.log[j].TypeLog == "renamed" && this.log[j].AfterLog == this.log[number].BeforeLog)
                {
                    number = j;
                }
                else
                {
                    if (this.log[j].TypeLog == "created" && this.log[number].BeforeLog == this.log[j].BeforeLog)
                    {
                        File.Delete(this.log[i].BeforeLog);
                        FileInfo file = new FileInfo(this.log[i].BeforeLog);
                        FileStream fs = file.Create();
                        fs.Close();
                        return;
                    }
                    else
                    {
                        if ((this.log[j].TypeLog == "changed" || this.log[j].TypeLog == "created with data") && this.log[number].BeforeLog == this.log[j].BeforeLog)
                        {
                            File.Delete(this.log[i].BeforeLog);
                            File.Copy(this.log[j].AfterLog, this.log[i].BeforeLog);
                            return;
                        }
                    }
                }
            }
        }

        private void BackDeleted(int i)
        {
            if (Path.GetExtension(this.log[i].BeforeLog) == ".txt")
            {
                int number = i;
                for (int j = number; j >= 0; j--)
                {
                    if (this.log[j].TypeLog == "renamed" && this.log[j].AfterLog == this.log[number].BeforeLog)
                    {
                        number = j;
                    }
                    else
                    {
                        if (this.log[j].TypeLog == "created" && this.log[number].BeforeLog == this.log[j].BeforeLog)
                        {
                            FileInfo file = new FileInfo(this.log[i].BeforeLog);
                            FileStream fs = file.Create();
                            fs.Close();
                            return;
                        }
                        else
                        {
                            if ((this.log[j].TypeLog == "changed" || this.log[j].TypeLog == "created with data") && this.log[number].BeforeLog == this.log[j].BeforeLog)
                            {
                                File.Copy(this.log[j].AfterLog, this.log[i].BeforeLog);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(this.log[i].BeforeLog);
            }
        }

        private void BackCreated(int i)
        {
            if (Path.GetExtension(this.log[i].BeforeLog) == ".txt")
            {
                File.Delete(this.log[i].BeforeLog);
            }
            else
            {
                Directory.Delete(this.log[i].BeforeLog);
            }
        }

        private void BackRenamed(int i)
        {
            if (Path.GetExtension(this.log[i].BeforeLog) == ".txt")
            {
                File.Move(this.log[i].AfterLog, this.log[i].BeforeLog);
            }
            else
            {
                Directory.Move(this.log[i].AfterLog, this.log[i].BeforeLog);
            }
        }

        private struct NoteLog
        {
            public string TypeLog;
            public string DateLog;
            public string BeforeLog;
            public string AfterLog;

            public NoteLog(string type, string date, string before, string after)
            {
                this.AfterLog = after;
                this.BeforeLog = before;
                this.DateLog = date;
                this.TypeLog = type;
            }
        }
    }
}
