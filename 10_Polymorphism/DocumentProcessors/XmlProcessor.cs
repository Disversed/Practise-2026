using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Polymorphism.DocumentProcessors
{
    public class XmlProcessor : DocumentProcessor
    {
        public XmlProcessor() { documentExtension = ".xml"; }

        protected override string ExtractData(string filePath)
        {
            Console.WriteLine("XML file is being processed...");
            return "xml_data";
        }
    }
}
