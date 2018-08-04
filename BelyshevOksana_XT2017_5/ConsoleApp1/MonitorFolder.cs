using System;
using System.Configuration;
using System.IO;

namespace ConsoleApp1
{
    public class MonitorFolder
    {
        private string pathFileLog;
        private string pathDirMonitor;
        private string pathDirBackups;
        private int index;
        private DateTime lastRead = DateTime.MinValue;
        private FileSystemWatcher watcher = new FileSystemWatcher();

        public MonitorFolder()
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
                dirBackups.Create();
            }

            FileInfo fileLog = new FileInfo(Path.Combine(dirMonitor.Parent.FullName.ToString(), "Log.txt"));
            if (!fileLog.Exists)
            {
                FileStream fs = fileLog.Create();
                fs.Close();
            }

            this.pathDirBackups = dirBackups.FullName;
            this.pathDirMonitor = dirMonitor.FullName;
            this.pathFileLog = fileLog.FullName;
            this.index = 0;
        }

        public void Run()
        {
            this.watcher.Path = this.pathDirMonitor;
            this.watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            this.watcher.Changed += new FileSystemEventHandler(this.OnChanged);
            this.watcher.Created += new FileSystemEventHandler(this.OnCreated);
            this.watcher.Deleted += new FileSystemEventHandler(this.OnDeleted);
            this.watcher.Renamed += new RenamedEventHandler(this.OnRenamed);

            this.watcher.IncludeSubdirectories = true;

            this.watcher.EnableRaisingEvents = true;

            Console.WriteLine("Enter E to exit");
            while (Console.ReadLine() != "e" && Console.ReadLine() != "E")
            {
            }
        }

        public void Stop()
        {
            this.watcher.EnableRaisingEvents = false;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastWriteTime != this.lastRead)
            {
                if (Path.GetExtension(e.FullPath) == ".txt")
                {
                    FileInfo fileInfo = new FileInfo(e.FullPath);
                    if (fileInfo.CreationTime < fileInfo.LastWriteTime)
                    {
                        string dateChanged = fileInfo.LastWriteTime.ToString("dd.MM.yy H.mm.ss.ms");
                        string fileChanged = Path.Combine(this.pathDirBackups, dateChanged + this.index++ + ".txt");
                        FileInfo file = new FileInfo(fileChanged);

                        if (!file.Exists)
                        {
                            Console.WriteLine($"{dateChanged} {e.FullPath} changed");
                            FileStream fs = file.Create();
                            fs.Close();
                            File.Copy(e.FullPath, fileChanged, true);

                            using (StreamWriter sw = new StreamWriter(this.pathFileLog, true))
                            {
                                sw.WriteLine("changed");
                                sw.WriteLine(dateChanged);
                                sw.WriteLine(e.FullPath);
                                sw.WriteLine(fileChanged);
                                sw.Close();
                            }
                        }
                    }
                }

                this.lastRead = lastWriteTime;
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (Path.GetExtension(e.FullPath) == ".txt" || Path.GetExtension(e.FullPath) == string.Empty)
            {
                DateTime dateTime = DateTime.Now;
                string dateCreated = dateTime.ToString("dd.MM.yy H.mm.ss.ms");

                Console.WriteLine($"{dateCreated} {e.FullPath} created");
                string backUpCreate = Path.Combine(this.pathDirBackups, dateCreated + this.index++ + ".txt");

                bool copied = false;
                if (Path.GetExtension(e.FullPath) == ".txt" && File.GetCreationTime(e.FullPath) > File.GetLastWriteTime(e.FullPath))
                {
                    while (!copied)
                    {
                        try
                        {
                            File.Copy(e.FullPath, backUpCreate, true);
                            using (StreamWriter sw = new StreamWriter(this.pathFileLog, true))
                            {
                                sw.WriteLine("created with data");
                                sw.WriteLine(dateCreated);
                                sw.WriteLine(e.FullPath);
                                sw.WriteLine(backUpCreate);
                                sw.Close();
                            }

                            copied = true;
                        }
                        catch (Exception)
                        {
                            copied = false;
                        }
                    }
                }

                if (!copied)
                {
                    using (StreamWriter sw = new StreamWriter(this.pathFileLog, true))
                    {
                        sw.WriteLine("created");
                        sw.WriteLine(dateCreated);
                        sw.WriteLine(e.FullPath);
                        sw.WriteLine();
                    }
                }
            }
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (Path.GetExtension(e.FullPath) == ".txt" || Path.GetExtension(e.FullPath) == string.Empty)
            {
                DateTime dateTime = DateTime.Now;
                string dateDeleted = dateTime.ToString("dd.MM.yy H.mm.ss.ms");

                Console.WriteLine($"{dateDeleted} : {e.FullPath.ToString()} deleted");

                using (StreamWriter sw = new StreamWriter(this.pathFileLog, true))
                {
                    sw.WriteLine("deleted");
                    sw.WriteLine(dateDeleted);
                    sw.WriteLine(e.FullPath);
                    sw.WriteLine();
                    sw.Close();
                }
            } 
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (Path.GetExtension(e.FullPath) == ".txt" || Path.GetExtension(e.FullPath) == string.Empty)
            {
                DateTime dateTime = DateTime.Now;
                string dateRenamed = dateTime.ToString("dd.MM.yy H.mm.ss.ms");

                Console.WriteLine($"{dateRenamed} {e.OldFullPath} renamed to {e.FullPath.ToString()}");

                using (StreamWriter sw = new StreamWriter(this.pathFileLog, true))
                {
                    sw.WriteLine("renamed");
                    sw.WriteLine(dateRenamed);
                    sw.WriteLine(e.OldFullPath);
                    sw.WriteLine(e.FullPath);
                    sw.Close();
                }
            }
        }
    }
}
