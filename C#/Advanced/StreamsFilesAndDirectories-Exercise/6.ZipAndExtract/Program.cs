using System;
using System.IO.Compression;

namespace _6.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktop = Environment
                .GetFolderPath(Environment.SpecialFolder.Desktop);

            ZipFile.CreateFromDirectory(@$"{desktop}\Original\", @$"{desktop}\Copy.zip");
            ZipFile.ExtractToDirectory(@$"{desktop}\Copy.zip", @$"{desktop}\Copy");
        }
    }
}
