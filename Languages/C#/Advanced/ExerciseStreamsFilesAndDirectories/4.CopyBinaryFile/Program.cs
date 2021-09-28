using System;
using System.IO;

namespace _4.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileStreamRead = new FileStream("copyMe.png", FileMode.Open);
            using FileStream fileStreamWrite = new FileStream(@"..\..\..\copy.png", FileMode.CreateNew);
            byte[] buffer = new byte[4096];

            while (fileStreamRead.Read(buffer, 0, buffer.Length) != 0)
            {
                fileStreamWrite.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
