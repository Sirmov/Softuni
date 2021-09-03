using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i + 1] == text[i])
                {
                    text.Remove(i + 1, 1);
                    i--;
                }
            }

            Console.WriteLine(text);
        }
    }
}
