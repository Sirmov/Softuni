using System;
using System.IO;

namespace _1.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = 0;
            using StreamReader sr = new StreamReader("input.txt");
            using StreamWriter sw = new StreamWriter(@"..\..\..\output.txt");

            string line = sr.ReadLine();
            while (line != null)
            {
                if (lines % 2 == 1)
                {
                    sw.WriteLine(line);
                    sw.WriteLine();
                }
                lines++;
                line = sr.ReadLine();
            }
        }
    }
}
