using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace _5_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "TelephoneBook.xml";

            using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 4;

                writer.WriteStartDocument();
                writer.WriteStartElement("MyContacts"); // <MyContacts>

                // Контакт 1
                writer.WriteStartElement("Contact"); // <Contact>
                writer.WriteAttributeString("TelephoneNumber", "+375 (25) 111-22-33");
                writer.WriteString("Иван Иванов");
                writer.WriteEndElement(); // </Contact>

                // Контакт 2
                writer.WriteStartElement("Contact");
                writer.WriteAttributeString("TelephoneNumber", "+375 (29) 555-44-33");
                writer.WriteString("Петр Петров");
                writer.WriteEndElement();

                // Контакт 3
                writer.WriteStartElement("Contact");
                writer.WriteAttributeString("TelephoneNumber", "+375 (29) 123-45-67");
                writer.WriteString("Анна Сидорова");
                writer.WriteEndElement();

                writer.WriteEndElement(); // </MyContacts>
                writer.WriteEndDocument();
            }

            Console.WriteLine($"File {fileName} was created");

            ReadAndPrintPhoneNumbers(fileName);
        }

        static void ReadAndPrintPhoneNumbers(string fileName)
        {
            Console.WriteLine("\n\tList of telephone numbers");

            //using (XmlTextReader reader = new XmlTextReader(fileName))
            //{
            //    while (reader.Read())
            //    {
            //        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Contact")
            //        {
            //            string phoneNumber = reader.GetAttribute("TelephoneNumber");

            //            if (!string.IsNullOrEmpty(phoneNumber))
            //            {
            //                Console.WriteLine(phoneNumber);
            //            }
            //        }
            //    }
            //}

            // Или так можно еще
            XPathDocument doc = new XPathDocument(fileName);
            XPathNavigator nav = doc.CreateNavigator();

            XPathNodeIterator iter = nav.Select("//Contact/@TelephoneNumber");
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current.Value);
            }

        }

    }
}
