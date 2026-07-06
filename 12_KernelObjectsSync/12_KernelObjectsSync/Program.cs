using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_KernelObjectsSync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var mutex = new Mutex(true, "test_mutex", out bool createdNew)) 
            {
                if (!createdNew)
                {
                    Console.WriteLine("This app is already running.\nPress any key to close the window...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                ManualResetEventDemo.Run();
                AutoResetEventDemo.Run();
            }
        }
    }
}
