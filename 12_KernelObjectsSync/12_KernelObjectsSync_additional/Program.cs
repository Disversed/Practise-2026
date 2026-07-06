using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_KernelObjectsSync_additional
{
    internal class Program
    {
        private static Semaphore semaphore = new Semaphore(3, 3);
        private static string logFilePath = "test.log";
        private static Logger logger = new Logger();

        public static void Main()
        {
            Console.WriteLine("\nSemaphore log test started...\n");
            using (var writer = new StreamWriter(logFilePath))
            {
                logger.Writer = writer;

                var threads = new List<Thread>();
                for (int i = 1; i <= 10; i++)
                {
                    int local = i;
                    threads.Add(new Thread(() => Worker($"Thread {local}")));
                }

                foreach (var thread in threads)
                {
                    thread.Start();
                }

                foreach (var thread in threads)
                {
                    thread.Join();
                }
            }
            Console.WriteLine("\nSemaphore log test completed...\n");
        }

        private static void Worker(string threadName)
        {
            logger.Log($"[{threadName}] Waiting...");
            Thread.Sleep(1000);
            semaphore.WaitOne();

            logger.Log($"[{threadName}] Access granted. Working...");
            Thread.Sleep(1000);

            logger.Log($"[{threadName}] Finishing...");
            semaphore.Release();
        }
    }

    public class Logger
    {
        private object locker = new object();
        public TextWriter Writer { get; set; }

        public Logger() : this(Console.Out) { }
        public Logger(TextWriter writer)
        {
            this.Writer = writer;
        }

        public void Log(string message)
        {
            string formattedMessage = $"[{DateTime.Now}] {message}";

            lock (locker)
            {
                Writer.WriteLine(formattedMessage);
            }
        }
    }

}
