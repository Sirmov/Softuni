using System;
using System.IO;

namespace _5.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using FileStream fileStreamReader = new FileStream("input.txt", FileMode.Open);
            int bytesPerFile = (int) Math.Ceiling(fileStreamReader.Length / 4.0);

            for (int i = 0; i < 4; i++)
            {
                byte[] buffer = new byte[bytesPerFile];
                fileStreamReader.Read(buffer);
                using FileStream fileStreamWriter = new FileStream(@$"..\..\..\Part{i + 1}.txt", FileMode.OpenOrCreate);
                fileStreamWriter.Write(buffer);
            }
        }
    }
}
