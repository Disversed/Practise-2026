using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _8_Serialization.Classes
{
    [Serializable]
    [XmlRoot(ElementName = "Employee")]
    public class EmployeeAsAttributes
    {
        [XmlAttribute(AttributeName = "FullName")]
        public string Name { get; set; }
        [XmlAttribute]
        public string Position { get; set; }
        [XmlAttribute]
        public double Salary { get; set; }

        public EmployeeAsAttributes() { }
        
        public EmployeeAsAttributes(string name, string position, double salary)
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
