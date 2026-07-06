using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Polymorphism.DocumentProcessors
{
    public abstract class DocumentProcessor
    {
        protected string documentExtension;

        public string ProcessDocument(string filePath)
        {
            filePath = filePath.Trim();
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("File path cannot be empty");

            if (!filePath.EndsWith(documentExtension))
                throw new ArgumentException($"Current proccesor can extract data only from {documentExtension} files");

            Console.WriteLine("1. Extracting file data...");
            string extractedData = ExtractData(filePath);

            Console.WriteLine("2. Completing processing...");
            OnProcessingCompleted();

            return extractedData;
        }

        protected abstract string ExtractData(string filePath);

        protected virtual void OnProcessingCompleted() { }
    }
}
