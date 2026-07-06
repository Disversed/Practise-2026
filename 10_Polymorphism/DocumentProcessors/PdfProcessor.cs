using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Polymorphism.DocumentProcessors
{
    public class PdfProcessor : DocumentProcessor
    {
        public PdfProcessor() { documentExtension = ".pdf"; }

        protected override string ExtractData(string filePath)
        {
            Console.WriteLine("PDF file is being processed...");
            return "pdf_data";
        }

        protected override void OnProcessingCompleted()
        {
            base.OnProcessingCompleted();
            Console.WriteLine("PDF file has been successfully processed");
        }
    }
}
