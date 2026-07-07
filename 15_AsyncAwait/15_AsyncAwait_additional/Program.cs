using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_Threads
{
    internal class Program
    {
        class Counter
        {
            public int Value;
        }

        static async Task Main(string[] args)
        {
            // Доп. задание
            Console.WriteLine("\n\tAdditional task");

            var counter = new Counter();
            var tasks = new List<Task>() {
                Task.Run(() => CountAsync(counter)),
                Task.Run(() => CountAsync(counter)),
                Task.Run(() => CountAsync(counter))
            };

            await Task.WhenAll(tasks);
        }

        static async Task CountAsync(Counter counter)
        {
            for (int i = 0; i < 10; i++)
            {
                Interlocked.Increment(ref counter.Value);
                Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] {counter.Value}");
                await Task.Delay(50);
            }
        }
    }
}
