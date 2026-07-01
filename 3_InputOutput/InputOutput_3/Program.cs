using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutput_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter directory path, where search will start (default = C:\\): ");
            string startPath = Console.ReadLine();
            startPath = String.IsNullOrWhiteSpace(startPath) ? "C:\\" : startPath;

            if (!Directory.Exists(startPath))
            {
                Console.WriteLine("\nThis directory doesn't exist");
                return;
            }

            Console.Write("Enter file name (default = test.txt): ");
            string fileName = Console.ReadLine();
            fileName = String.IsNullOrWhiteSpace(fileName) ? "test.txt" : fileName;
            

            string filePath = FindFile(startPath, fileName);

            if (filePath == null)
            {
                Console.WriteLine("\nThis file doesn't exist in given directory or in its subdirectories");
                return;
            }

            Console.WriteLine($"\nThe file was found at the path {filePath}\n");
            PrintFile(filePath);

            Console.WriteLine($"\nThe file was compressed at the same path");
            CompressFile(filePath);

            // Доп. задание
            string testFolderPath = Path.Combine("..", "100missedcalls");
            var dir = Directory.CreateDirectory(testFolderPath);
            for (int i = 0; i < 100; i++)
            {
                string folderPath = Path.Combine(testFolderPath, $"Folder_{i}");
                Directory.CreateDirectory(folderPath);
            }
            Directory.Delete(testFolderPath, true);
        }

        static string FindFile(string path, string fileName)
        {
            try
            {
                string[] files = Directory.GetFiles(path, fileName);
                if (files.Length > 0) return files[0];

                var currentDirInfo = new DirectoryInfo(path);

                foreach (var subDir in currentDirInfo.GetDirectories())
                {
                    try
                    {
                        // Решил пропускать скрытые и системные файлы
                        if (subDir.Attributes.HasFlag(FileAttributes.Hidden) ||
                            subDir.Attributes.HasFlag(FileAttributes.System)) { continue; }

                        string filePath = FindFile(subDir.FullName, fileName);
                        if (filePath != null) return filePath;
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Debug.WriteLine($"[Skip] {subDir.FullName}: {ex.Message}");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine($"Access error at {path}: {ex.Message}");
            }

            return null;
        }

        static void PrintFile(string filePath)
        {
            using (var source = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(source))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        static void CompressFile(string filePath)
        {
            string compressedFilePath = filePath + ".gz";

            using (var source = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var target = new FileStream(compressedFilePath, FileMode.Create))
                {
                    using (var compression = new GZipStream(target, CompressionMode.Compress))
                    {
                        source.CopyTo(compression);
                    }
                }
            }
        }
    }
}
