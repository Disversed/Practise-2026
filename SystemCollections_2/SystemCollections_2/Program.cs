using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCollections_2.CustomOrderedDictionary;

namespace SystemCollections_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание №1
            Console.WriteLine("\tTask 1. Diffirent ways to create a key-value collection for only number values:");
            var collections = new List<object>();
            collections.Add(new Dictionary<int, decimal>());
            collections.Add(new SortedDictionary<int, decimal>());
            collections.Add(new SortedList<int, decimal>());
            collections.Add(new ConcurrentDictionary<int, decimal>());
            foreach(var coll in collections)
            {
                Console.WriteLine(coll.ToString());
            }

            // Задание №2
            Console.WriteLine("\n\tTask 2. Custom collection OrderedDictionaryWrap<TKey, TValue>:");
            var testDict = new OrderedDictionaryWrap<string, int>(StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("\n\tOriginal order of elements:");
            testDict.Add("First", 100);
            testDict.Add("Second", 101);
            testDict.Add("Third", 102);
            testDict.Add("Fourth", 103);
            PrintOrderedDictionay(testDict);


            Console.WriteLine("\n\tTest of duplicates (case-insensitive keys):");
            try
            {
                testDict.Add("first", 200);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}");
            }


            Console.WriteLine("\n\tTest of key indexer:");
            Console.WriteLine($"[SECOND] => {testDict["SECOND"]}"); // 101

            Console.WriteLine("\n\tTest of index indexer:");
            Console.WriteLine($"[1]: {testDict[1]}"); // 101

            Console.WriteLine("\n\tТеst (Insert):");
            testDict.Insert(1, "InsertedKey", 104);
            PrintOrderedDictionay(testDict);

            Console.WriteLine("\n\tTest (Remove)");
            bool isRemoved = testDict.Remove("INSERTEDKEY");
            Console.WriteLine($"Удаление успешно: {isRemoved}");
            PrintOrderedDictionay(testDict);

            Console.WriteLine("\n\tTest (Clear)");
            testDict.Clear();
            Console.WriteLine($"Elements in collection after clearing: {testDict.Count}");

            // Доп. задание
            Console.WriteLine("\n\tAdditional task (SortedList):");
            var list = new SortedList<string, int>(StringComparer.Ordinal);
            list.Add("First", 100);
            list.Add("Second", 101);
            list.Add("Third", 102);
            list.Add("Fourth", 103);

            Console.WriteLine("\n\tSorted in alphabetical order:");
            PrintSortedList(list);

            Console.WriteLine("\n\tSorted in opposite alphabetical order:");
            var ordinalDescending = new SortedList<string, int>(list, Comparer<string>.Create((x, y) => StringComparer.Ordinal.Compare(y, x)));
            PrintSortedList(ordinalDescending);
        }

        static void PrintOrderedDictionay<TKey, TValue>(OrderedDictionaryWrap<TKey, TValue> collection)
        {
            foreach (var pair in collection)
            {
                Console.WriteLine($"[{pair.Key}] => {pair.Value}");
            }
        }

        static void PrintSortedList<TKey, TValue>(SortedList<TKey, TValue> collection)
        {
            foreach (var pair in collection)
            {
                Console.WriteLine($"[{pair.Key}] => {pair.Value}");
            }
        }
    }
}
