using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_AppDomain_Winform
{
    public partial class Form1 : Form
    {
        private string serviceName = "DriveMonitorService";
        private string serviceExePath = Path.Combine(Directory.GetCurrentDirectory(), "16_AppDomain_Service.exe");
        private string logFilePath = @"C:\Temp\deleted_files_log.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void RunCommand(string fileName, string arguments)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                CreateNoWindow = true,
                UseShellExecute = false,
            };
            Process.Start(processInfo);
        }

        private void InstallBtn_Click(object sender, EventArgs e)
        {
            RunCommand("sc", $"create \"{serviceName}\" binPath= \"{serviceExePath}\" start= auto");
            MessageBox.Show("Service intall command was sent");
        }

        private void UninstallBtn_Click(object sender, EventArgs e)
        {
            RunCommand("sc", $"delete \"{serviceName}\"");
            MessageBox.Show("Service unintall command was sent");
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sc = new ServiceController(serviceName))
                {
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
                        MessageBox.Show($"Service {serviceName} is running");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sc = new ServiceController(serviceName))
                {
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(5));
                        MessageBox.Show($"Service {serviceName} is stopped");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void updateLogBoxTimer_Tick(object sender, EventArgs e)
        {
            if (!File.Exists(logFilePath)) return;

            using (var fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(fs))
            {
                logBox.Text = reader.ReadToEnd();
            }
        }
    }
}
