using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithText_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string fileName = "receipt.txt";
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine("2026-07-01 14:30:00");
                writer.WriteLine("Sofa 1300");
                writer.WriteLine("Table 400,50");
                writer.WriteLine("Chair 89,99");
                writer.WriteLine("Bed 2100");
                writer.WriteLine("Closet 1600");
            }

            Console.WriteLine($"\tReceipt file {fileName} was created");

            Console.WriteLine($"\n\tOutput with current culture ({CultureInfo.CurrentCulture.Name})");
            PrintReceipt(fileName, CultureInfo.CurrentCulture);

            var cultureUS = new CultureInfo("en-US");
            Console.WriteLine($"\n\tOutput with culture {cultureUS.Name}");
            PrintReceipt(fileName, cultureUS);
        }

        static void PrintReceipt(string fileName, CultureInfo culture)
        {
            using (var reader = new StreamReader(fileName))
            {
                string date = reader.ReadLine();
                if (DateTime.TryParse(date, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime purchaseDate))
                {
                    Console.WriteLine($"Purchase date: {purchaseDate.ToString("D", culture)}");
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    string itemName = parts[0];
                    if (double.TryParse(parts[1], NumberStyles.Currency, CultureInfo.InvariantCulture, out double itemCost))
                    {
                        Console.WriteLine($"{itemName}: {itemCost.ToString("C", culture)}");
                    }
                }
            }
        }
    }
}
