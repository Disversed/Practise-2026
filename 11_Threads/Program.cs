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
        static private string fileSource1 = "doc1.txt";
        static private string fileSource2 = "doc2.txt";
        static private string fileTarget = "docTarget.txt";
        static private object locker = new object();

        static void Main(string[] args)
        {
            using (var writer = new StreamWriter(fileTarget))
            {
                var thread1 = new Thread(() => ReadAndAppendFile(fileSource1, writer, "Thread 1"));
                var thread2 = new Thread(() => ReadAndAppendFile(fileSource2, writer, "Thread 2"));

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();
            }

            // Доп. задание
            Console.WriteLine("\n\tAdditional task");
            int counter = 0;
            var thread3 = new Thread(() => CountInThread(ref counter, locker, "Thread 3"));
            var thread4 = new Thread(() => CountInThread(ref counter, locker, "Thread 4"));
            var thread5 = new Thread(() => CountInThread(ref counter, locker, "Thread 5"));

            thread3.Start();
            thread4.Start();
            thread5.Start();

            thread3.Join();
            thread4.Join();
            thread5.Join();
        }

        static void ReadAndAppendFile(string fileSource, StreamWriter fileTargetWriter, string threadName)
        {
            using (var reader = new StreamReader(fileSource))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"[{threadName}] {line}");
                    Thread.Sleep(100);
                    lock(locker)
                    {
                        fileTargetWriter.WriteLine(line);
                    }
                }
            }
        }

        static void CountInThread(ref int counter, object locker, string threadName)
        {
            for (int i = 0; i < 10; i++)
            {
                lock (locker)
                {
                    Console.WriteLine($"[{threadName}] {1+counter++}");
                }
                Thread.Sleep(50);
            }
        }
    }
}
