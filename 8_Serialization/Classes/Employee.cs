using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace _8_Serialization.Classes
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public Employee() { }
        
        public Employee(string name, string position, double salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {{\n\tName = {Name}\n\tPosition = {Position}\n\tSalary = {Salary}\n}}";
        }
    }
}
