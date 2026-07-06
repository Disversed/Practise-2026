using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _9_MemoryManagement.Monitor
{
    public class MemoryMonitor
    {
        public long MemoryLimitBytes { get; }
        public double WarningThreshold { get; }
        public long CurrentUsage { get; private set; }

        public MemoryMonitor(long limitMegabytes, int warningPercentage)
        {
            MemoryLimitBytes = limitMegabytes * 1024 * 1024;
            WarningThreshold = warningPercentage / 100.0;
        }

        public void Start(int checkIntervalMilliseconds)
        {
            Console.WriteLine($"[Monitor] Started. Memory limit: {MemoryLimitBytes / 1024 / 1024} MB.");

            Task.Run(() =>
            {
                CurrentUsage = 0;
                while (CurrentUsage < MemoryLimitBytes)
                {
                    CurrentUsage = GC.GetTotalMemory(false);
                    Thread.Sleep(checkIntervalMilliseconds);
                }
            });
        }

        public void Status() {
            double usagePercentage = (double)CurrentUsage / MemoryLimitBytes;

            if (usagePercentage >= WarningThreshold)
            {
                Console.WriteLine($"\n[Warning] Allocated memory is near the limit!");
                Console.WriteLine($"Выделено в куче: {CurrentUsage / 1024 / 1024} МБ из {MemoryLimitBytes / 1024 / 1024} МБ ({usagePercentage:P1})");
            }

            if (CurrentUsage >= MemoryLimitBytes)
            {
                Console.WriteLine($"\n[Warning] Allocated memory limit has been exceeded!");
            }
        }
    }
}
