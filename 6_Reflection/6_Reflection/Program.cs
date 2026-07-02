using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _6_Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dllName = "TemperatureConverterLib.dll";
            string dllPath = Path.Combine("..", dllName);

            if (!File.Exists(dllPath))
            {
                Console.WriteLine($"Assembly file wasn't found at path {dllPath}");
                return;
            }

            try
            {
                Console.WriteLine("\tTemperature converter");

                Assembly assembly = Assembly.LoadFrom(dllPath);
                Console.WriteLine($"Assembly {dllName} was successfully loaded");

                string className = "TemperatureConverterLib.Converter";
                Type converterType = assembly.GetType(className);
                if (converterType == null)
                {
                    Console.WriteLine($"Class {className} wasn't found in assembly");
                    return;
                }

                MethodInfo celsiusToFahrenheitMethod = converterType.GetMethod("CelsiusToFahrenheit");
                MethodInfo fahrenheitToCelsiusMethod = converterType.GetMethod("FahrenheitToCelsius");

                if (celsiusToFahrenheitMethod == null)
                {
                    Console.WriteLine("Method 'CelsiusToFahrenheit' wasn't found");
                    return;
                } else if (fahrenheitToCelsiusMethod == null)
                {
                    Console.WriteLine("Method 'FahrenheitToCelsius' wasn't found");
                    return;
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\tTemperature converter");
                    Console.WriteLine("\n1. From Celsisus to Fahrenheit");
                    Console.WriteLine("2. From Fahrenheit to Celsisus");
                    Console.WriteLine("3. Exit");
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    MethodInfo method;
                    string fromDegrees, toDegrees;
                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            method = celsiusToFahrenheitMethod;
                            fromDegrees = "°C";
                            toDegrees = "°F";
                            break;
                        case ConsoleKey.D2:
                            method = fahrenheitToCelsiusMethod;
                            fromDegrees = "°F";
                            toDegrees = "°C";
                            break;
                        case ConsoleKey.D3:
                            return;
                        default:
                            continue;
                    }

                    Console.Clear();
                    Console.WriteLine("\tTemperature converter");
                    Console.Write("\nEnter temperature value: ");
                    if (double.TryParse(Console.ReadLine(), out double degreesValue))
                    {
                        // Параметр для передачи в метод
                        object[] parameters = new object[] { degreesValue };

                        object result = method.Invoke(converterType, parameters);

                        Console.WriteLine($"{degreesValue}{fromDegrees} = {result}{toDegrees}");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect number was entered");
                    }

                    Console.WriteLine("\nEnter any key to continue...");
                    Console.ReadKey();
                }
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine($"Error in invocated method: {ex.InnerException?.Message}");
            }
        }
    }
}
