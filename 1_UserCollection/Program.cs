using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCollections_1.Collection;

namespace UserCollections_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var civilians = new CivilianCollection();

            civilians.Add(new Worker(1000));
            civilians.Add(new Worker(1001));
            civilians.Add(new Pensioner(1002));
            civilians.Add(new Student(1003));
            civilians.Add(new Pensioner(1004));
            civilians.Add(new Student(1005));
            civilians.Add(new Worker(1006));

            Console.WriteLine("Original queue:");
            foreach (Civilian civilian in civilians)
            {
                Console.WriteLine(civilian.ToString());
            }

            Civilian civ;

            // Тест метода Contains
            Console.WriteLine("\nTest (Contains):");
            civ = new Worker(1001);
            if (civilians.Contains(civ, out int position))
            {
                Console.WriteLine($"A civilian with passport ID #{civ.PassportID} was found in queue on position {position}");
            }
            civ = new Student(9999);
            if (!civilians.Contains(civ, out position))
            {
                Console.WriteLine($"A civilian with passport ID #{civ.PassportID} wasn't found in queue. Returned position is {position}");
            }

            // Тест метода ReturnLast
            Console.WriteLine("\nTest (ReturnLast):");
            civ = civilians.ReturnLast(out int lastPos);
            if (civ != null)
            {
                Console.WriteLine($"The last civilian in queue:\n{civ} (position is {lastPos})");
            }

            // Тест методов RemoveFirst, Remove
            Console.WriteLine("\nTest (RemoveFirst, Remove):");
            civ = new Student(1003);
            Console.WriteLine($"Removing the first civilian in queue and the civilian {civ}");
            civilians.RemoveFirst();
            civilians.Remove(civ);
            Console.WriteLine("\nQueue after removing civilians:");
            foreach (Civilian civilian in civilians)
            {
                Console.WriteLine(civilian.ToString());
            }

            // Тест метода Clear
            Console.WriteLine("\nTest (Clear):");
            civilians.Clear();
            civilians.ReturnLast(out lastPos);
            Console.WriteLine($"Position of the last civilian after clearing: {lastPos}");

            // Тест доп. метода (коллекцию квадратов всех нечётных чисел массива)
            Console.WriteLine("\nTest (GetSquaresOfOddNumbers):");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            foreach (int num in arr)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            var squares = GetSquaresOfOddNumbers(arr);
            foreach (int square in squares)
            {
                Console.Write($"{square} ");
            }
        }

        static IEnumerable<int> GetSquaresOfOddNumbers(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0) yield return arr[i] * arr[i];
            }
        }
    }
}
