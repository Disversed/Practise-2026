using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14_TPL_additional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var arr = new int[10_000_000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }

            var watch = Stopwatch.StartNew();
            var oddNumbersAsParallel = arr.AsParallel().Where(x => x % 2 == 1).ToArray();
            watch.Stop();

            Console.WriteLine($"PLINQ request execution time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Total odd numbers in array: {oddNumbersAsParallel.Length}");

            watch.Restart();
            var oddNumbers = arr.Where(x => x % 2 == 1).ToArray();
            watch.Stop();

            Console.WriteLine($"\nLINQ request execution time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Total odd numbers in array: {oddNumbers.Length}");

        }
    }
}
