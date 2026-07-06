using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_KernelObjectsSync
{
    public class AutoResetEventDemo
    {
        private static AutoResetEvent autoEvent = new AutoResetEvent(false);

        public static void Run()
        {
            Console.WriteLine("\n\tAutoResetEventDemo\n");

            new Thread(() => Worker("Thread 1")).Start();
            new Thread(() => Worker("Thread 2")).Start();

            Thread.Sleep(2000);

            Console.WriteLine("\n[Main thread]: Sending signal (Set)...\n");
            autoEvent.Set();

            Thread.Sleep(500);

            autoEvent.Set();
        }

        private static void Worker(string threadName)
        {
            Console.WriteLine($"[{threadName}]: Waiting for a signal...");
            autoEvent.WaitOne();
            Console.WriteLine($"[{threadName}]: Signal has been received");
        }

    }
}
