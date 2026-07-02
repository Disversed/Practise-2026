using _7_Attributes_Additional.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _7_Attributes_Additional
{
    internal static class SecuritySystem
    {
        public static void TryEnterProtectedSection(Employee employee, AccessLevel requiredLevel)
        {
            Type employeeType = employee.GetType();
            string employeeName = employee.Name;

            Console.WriteLine($"Employee {employeeName} ({employeeType.Name}) tries to enter protected section [{requiredLevel}]... ");

            AccessLevelAttribute accessAttribute = employeeType.GetCustomAttribute<AccessLevelAttribute>();

            if (accessAttribute.Level >= requiredLevel)
            {
                Console.WriteLine($"Access GRANTED. (Level: {accessAttribute.Level})\n");
            }
            else
            {
                Console.WriteLine($"Access DENIED. Your access level [{accessAttribute.Level}] is too low.\n");
            }
        }
    }
}
