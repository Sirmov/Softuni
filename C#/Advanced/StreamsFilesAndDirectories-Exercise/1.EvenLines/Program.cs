using System;
using System.IO;

namespace _1.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("text.txt");
            char[] oldChars = new char[] { '-', ',', '.', '!', '?' };

            int lines = 0;
            string line = sr.ReadLine();
            while (line != null)
            {
                if (lines % 2 == 0)
                {
                    string[] words = line.Split();
                    Array.Reverse(words);
                    line = string.Join(" ", words);

                    foreach (var oldChar in oldChars)
                    {
                        line = line.Replace(oldChar, '@');
                    }

                    Console.WriteLine(line);
                }

                lines++;
                line = sr.ReadLine();
            }
        }
    }
}
