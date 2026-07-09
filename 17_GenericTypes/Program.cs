using _17_GenericTypes.Storage;
using _17_GenericTypes.StorageItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_GenericTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tUniversal storage test");

            Storage<Book> bookStorage = new Storage<Book>();
            bookStorage.AddItem(new Book { Title = "Crime and punishment", Author = "F. Dostoevsky" });
            bookStorage.AddItem(new Book { Title = "1984", Author = "G. Orwell" });
            bookStorage.AddItem(new Book { Title = "The Master and Margarita", Author = "M. Bulgakov" });

            Book foundBook = FindItem(bookStorage.GetAll(), b => b.Author == "G. Orwell");
            Console.WriteLine($"\n[Book search]: Result -> {foundBook}");


            Console.WriteLine("\n------------------------------------------------");
            Storage<Phone> phoneStorage = new Storage<Phone>();
            phoneStorage.AddItem(new Phone { Model = "iPhone 15", Price = 999 });
            phoneStorage.AddItem(new Phone { Model = "Samsung Galaxy S24", Price = 850 });
            phoneStorage.AddItem(new Phone { Model = "Redmi Note 13", Price = 250 });

            Phone budgetPhone = FindItem(phoneStorage.GetAll(), p => p.Price < 500);
            Console.WriteLine($"\n[Phone search]: Result -> {budgetPhone}");


            Console.WriteLine("\n------------------------------------------------");
            Storage<Fruit> fruitStorage = new Storage<Fruit>();
            fruitStorage.AddItem(new Fruit { Name = "Apples", Weight = 15.5 });
            fruitStorage.AddItem(new Fruit { Name = "Bananas", Weight = 42.0 });
            fruitStorage.AddItem(new Fruit { Name = "Oranges", Weight = 8.3 });

            Fruit heavyFruit = FindItem(fruitStorage.GetAll(), f => f.Weight > 20.0);
            Console.WriteLine($"\n[Fruit search]: Result -> {heavyFruit}");

            Console.WriteLine("\n[Delete test]: Deleting oranges...");
            var allFruits = fruitStorage.GetAll();
            Fruit fruitToDelete = FindItem(allFruits, f => f.Name == "Oranges");
            if (fruitToDelete != null)
            {
                fruitStorage.RemoveItem(fruitToDelete);
            }

            Console.WriteLine($"Types of fruits left in the storage: {fruitStorage.GetAll().Count}");
        }

        static T FindItem<T>(IEnumerable<T> collection, Predicate<T> searchСondition)
        {
            foreach (var item in collection)
            {
                if (searchСondition(item))
                    return item;
            }

            return default;
        }

        static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
    }
}
