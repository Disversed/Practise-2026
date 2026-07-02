using _8_Serialization.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _8_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Иван Иванов";
            string position = "Инженер";
            double salary = 3200;
            var emp1 = new Employee(name, position, salary);
            var emp2 = new EmployeeAsAttributes(name, position, salary);

            var formatter1 = new XmlSerializer(emp1.GetType());
            var formatter2 = new XmlSerializer(emp2.GetType());

            try
            {
                using (var fs = new FileStream("default_format.xml", FileMode.Create))
                {
                    formatter1.Serialize(fs, emp1);
                    Console.WriteLine("Object 'Employee' was succesfully serialized (default_format.xml)\n");
                }

                using (var fs = new FileStream("attribute_format.xml", FileMode.Create))
                {
                    formatter2.Serialize(fs, emp2);
                    Console.WriteLine("Object 'EmployeeAsAttributes' was succesfully serialized (attribute_format.xml)\n");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Enter any key to continue...\n");
            Console.ReadKey();

            try
            {
                using (var fs = new FileStream("default_format.xml", FileMode.Open))
                {
                    var emp = (Employee)formatter1.Deserialize(fs);
                    Console.WriteLine(emp);
                    Console.WriteLine("Object 'Employee' was succesfully deserialized (default_format.xml)\n");
                }

                using (var fs = new FileStream("attribute_format.xml", FileMode.Open))
                {
                    var emp = (EmployeeAsAttributes)formatter2.Deserialize(fs);
                    Console.WriteLine(emp);
                    Console.WriteLine("Object 'EmployeeAsAttributes' was succesfully deserialized (attribute_format.xml)\n");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
