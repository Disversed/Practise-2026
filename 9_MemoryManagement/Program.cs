using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _9_MemoryManagement.Monitor;

namespace _9_MemoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter memory limit (MB): ");
            bool isMemoryLimitValid = ulong.TryParse(Console.ReadLine(), out ulong memoryLimit);
            Console.Write("Enter warning percentage: ");
            bool isWarningPercentageValid = uint.TryParse(Console.ReadLine(), out uint warningPercentage);

            if (!isMemoryLimitValid || !isMemoryLimitValid || warningPercentage > 100)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            MemoryMonitor monitor = new MemoryMonitor((long)memoryLimit, (int)warningPercentage);
            monitor.Start(100);

            Console.WriteLine("\nPress any key to start memory usage simulation...");
            Console.ReadKey();

            List<MemoryEater> memoryEaters = new List<MemoryEater>();
            try
            {
                for (int i = 0; monitor.CurrentUsage <= monitor.MemoryLimitBytes; i++)
                {
                    Console.WriteLine($"Allocating 10 MB... ({i + 1})");
                    memoryEaters.Add(new MemoryEater());
                    monitor.Status();
                    Thread.Sleep(500);
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }

            monitor.Status();
        }
    }
}
