using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace _16_AppDomain_Service
{
    public partial class Service : ServiceBase
    {
        private List<FileSystemWatcher> watchers;
        private string logFilePath = @"C:\Temp\deleted_files_log.txt";
        private static object locker = new object();

        public Service()
        {
            InitializeComponent();
            this.ServiceName = "DriveMonitorService";
            this.watchers = new List<FileSystemWatcher>();
        }

        protected override void OnStart(string[] args)
        {
            Directory.CreateDirectory(@"C:\Temp");
            if (!File.Exists(logFilePath)) File.Create(logFilePath).Close();

            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.DriveType == DriveType.Fixed)
                {
                    var watcher = new FileSystemWatcher(drive.Name);
                    watcher.IncludeSubdirectories = true;
                    watcher.Deleted += Watcher_Deleted;
                    watcher.EnableRaisingEvents = true;
                    watchers.Add(watcher);
                }
            }
        }

        protected override void OnStop()
        {
            foreach (var watcher in watchers)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
            }
            watchers.Clear();
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            lock (locker)
            {
                File.AppendAllText(logFilePath, $"[{DateTime.Now}] Deleted: {e.FullPath}{Environment.NewLine}");
            }
        }
    }
}
