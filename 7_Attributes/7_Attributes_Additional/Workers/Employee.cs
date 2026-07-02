using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Attributes_Additional.Workers
{
    internal abstract class Employee
    {
        public string Name { get; }

        public Employee(string name) => Name = name;
    }
}
