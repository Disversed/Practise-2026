using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14_TPL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();

            Console.WriteLine("[Main] Starting...");
            Console.WriteLine("[Main] Press any key to exit");
            Thread.Sleep(1000);

            Task.Run(() =>
            {
                Parallel.Invoke(Calculate, ProcessText);
            }, tokenSource.Token);

            Console.ReadKey();
            tokenSource.Cancel();
            Console.WriteLine("[Main] Finishing...");
        }

        static void Calculate()
        {
            while (true)
            {
                Console.WriteLine("Calculating...");
                Thread.Sleep(1000);
            }
        }

        static void ProcessText()
        {
            while (true)
            {
                Console.WriteLine("Processing text...");
                Thread.Sleep(800);
            }
        }
    }
}
