using System;
using System.IO;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                File.AppendAllLines(@"..\..\..\output.txt",
                    new string[] { $"{i + 1}.  {lines[i]}" });
            }
        }
    }
}
