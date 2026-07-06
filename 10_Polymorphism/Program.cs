using _10_Polymorphism.DocumentProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pdfProc = new PdfProcessor();
            var xmlProc = new XmlProcessor();

            string pdfData, xmlData;
            pdfData = pdfProc.ProcessDocument("Document1.pdf");
            Console.WriteLine($"Data from PDF document: {pdfData}\n");

            xmlData = xmlProc.ProcessDocument("Document2.xml");
            Console.WriteLine($"Data from PDF document: {xmlData}\n");
        }
    }
}
