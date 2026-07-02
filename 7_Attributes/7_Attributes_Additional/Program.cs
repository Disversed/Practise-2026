using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _7_Attributes_Additional.Workers;

namespace _7_Attributes_Additional
{
    public enum AccessLevel
    {
        Low,
        Medium,
        High
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Алексей");
            Programmer programmer = new Programmer("Дмитрий");
            Director director = new Director("Валерий");

            Console.WriteLine("\tServer room (min. access level: Medium)\n");
            SecuritySystem.TryEnterProtectedSection(manager, AccessLevel.Medium);
            SecuritySystem.TryEnterProtectedSection(programmer, AccessLevel.Medium);
            SecuritySystem.TryEnterProtectedSection(director, AccessLevel.Medium);

            Console.WriteLine("\n\tVery important safe (min. access level: High)\n");
            SecuritySystem.TryEnterProtectedSection(manager, AccessLevel.High);
            SecuritySystem.TryEnterProtectedSection(programmer, AccessLevel.High);
            SecuritySystem.TryEnterProtectedSection(director, AccessLevel.High);
        }
    }
}
