using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintASCIIRange(start, end);
        }

        static void PrintASCIIRange(char first, char last)
        {
            int start = (int) Math.Min(first, last);
            int end = (int) Math.Max(first, last);
            

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char) i + " ");
            }
        }
    }
}
