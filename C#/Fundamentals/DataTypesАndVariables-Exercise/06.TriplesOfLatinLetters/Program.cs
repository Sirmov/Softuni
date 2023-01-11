using System;

namespace _06.TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            for (int i = 97; i < 97 + end; i++)
            {
                for (int j = 97; j < 97 + end; j++)
                {
                    for (int k = 97; k < 97 + end; k++)
                    {
                        Console.WriteLine($"{(char)i}{(char)j}{(char)k}");
                    }
                }
            }
        }
    }
}
