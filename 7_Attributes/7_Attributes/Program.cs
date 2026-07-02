using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _7_Attributes
{
    internal class Program
    {
        // Переменные для хранения настроек фильтрации пользователя
        static bool showFields = false;
        static bool showProperties = false;
        static bool showConstructors = false;
        static bool showMethods = false;

        static void Main(string[] args)
        {
            string systemDllPath = typeof(System.Math).Assembly.Location;
            Console.WriteLine($"Example: {systemDllPath}");

            Console.WriteLine("\tREFLECTOR");

            Console.Write("Enter full path to assembly file (.dll): ");
            string dllPath = Console.ReadLine()?.Trim('"', ' ');

            if (string.IsNullOrEmpty(dllPath) || !File.Exists(dllPath))
            {
                Console.WriteLine("The specified file wasn't found");
                return;
            }

            ConfigureFilters();

            try
            {
                Assembly assembly = Assembly.LoadFrom(dllPath);

                Console.WriteLine($"\nAssembly was succesfully loaded: {assembly.FullName}");

                Type[] types = assembly.GetTypes();
                Console.WriteLine($"\nTotal types found (classes/structures/intefaces): {types.Length}\n");

                foreach (Type type in types)
                {
                    ReflectType(type);
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Assembly reflection error: {ex.Message}");
            }
        }

        static bool AskUser(string question)
        {
            Console.Write($"{question} (Y/n): ");
            return Console.ReadLine()?.ToLower() != "n";
        }

        static void ConfigureFilters()
        {
            Console.WriteLine("\n\tType members display settings");
            showFields = AskUser("Display fields");
            showProperties = AskUser("Display properties");
            showConstructors = AskUser("Display constructors");
            showMethods = AskUser("Display methods");
        }

        static void ReflectType(Type type)
        {
            // Определяем, что это за тип (класс, структура или интерфейс)
            string typeKind = type.IsInterface ? "interface" : type.IsValueType ? "struct" : "class";
            Console.WriteLine($"-> {typeKind}: {type.FullName}");

            // Поля
            //FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            FieldInfo[] fields = type.GetFields();
            if (fields.Length > 0 && showFields)
            {
                Console.WriteLine("\tFields:");
                foreach (FieldInfo field in fields)
                {
                    PrintAttributes(field);
                    string access = field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected/internal";
                    Console.WriteLine($"\t\t{access} {field.FieldType.Name} {field.Name}");
                }
            }

            // Свойства
            //PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            PropertyInfo[] properties = type.GetProperties();
            if (properties.Length > 0 && showProperties)
            {
                Console.WriteLine("\tProperties:");
                foreach (PropertyInfo prop in properties)
                {
                    PrintAttributes(prop);
                    Console.WriteLine($"\t\t{prop.PropertyType.Name} {prop.Name} {{ {(prop.CanRead ? "get;" : "")} {(prop.CanWrite ? "set;" : "")} }}");
                }
            }

            // Конструкторы
            ConstructorInfo[] constructors = type.GetConstructors();
            if (constructors.Length > 0 && showConstructors)
            {
                Console.WriteLine("\tConstructors:");
                foreach (ConstructorInfo ctor in constructors)
                {
                    PrintAttributes(ctor);
                    string access = ctor.IsPublic ? "public" : ctor.IsPrivate ? "private" : "protected/internal";
                    Console.Write($"\t\t{access} {type.Name}(");
                    PrintParameters(ctor.GetParameters());
                    Console.WriteLine(")");
                }
            }

            // Методы
            //MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
            MethodInfo[] methods = type.GetMethods();
            if (methods.Length > 0 && showMethods)
            {
                Console.WriteLine("\tMethods:");
                foreach (MethodInfo method in methods)
                {
                    PrintAttributes(method);
                    string access = method.IsPublic ? "public" : method.IsPrivate ? "private" : "protected/internal";
                    Console.Write($"\t\t{access} {method.ReturnType.Name} {method.Name}(");
                    PrintParameters(method.GetParameters());
                    Console.WriteLine(")");
                }
            }
        }

        static void PrintAttributes(MemberInfo member)
        {
            object[] attributes = member.GetCustomAttributes(false);

            if (attributes.Length > 0)
            {
                foreach (object attr in attributes)
                {
                    Console.WriteLine($"\t\t[{attr.GetType().Name}]");
                }
            }
        }

        static void PrintParameters(ParameterInfo[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                if (i < parameters.Length - 1) Console.Write(", ");
            }
        }

    }
}
