using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            foreach (char letter in word)
            {
                if (letter != ' ')
                {
                    if (!occurrences.ContainsKey(letter))
                    {
                        occurrences.Add(letter, 0);
                    }
                    occurrences[letter]++;
                }
            }

            foreach (var letter in occurrences)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
