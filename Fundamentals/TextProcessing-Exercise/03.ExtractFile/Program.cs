using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string[] file = path.Substring(path.LastIndexOf("\\") + 1).Split('.');
            string fileName = file[0];
            string fileExtension = file[1];
            Console.WriteLine($"File name: {fileName}\r\nFile extension: {fileExtension}");
        }
    }
}
