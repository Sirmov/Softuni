using System;
using System.IO;

namespace _6.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"..\..\..\TestFolder");
            double size = 0;

            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                size += fi.Length;
            }

            File.WriteAllText(@"..\..\..\megabytes.txt", $"{size / 1024 / 1024} mb");
        }
    }
}
