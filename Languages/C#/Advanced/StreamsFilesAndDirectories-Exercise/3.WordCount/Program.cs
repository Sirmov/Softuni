using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] punctuationChars = GetAllPunctuationChars();
            string[] targetWords = File.ReadAllLines("words.txt");
            string text = File.ReadAllText("text.txt");
            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            foreach (var word in targetWords)
            {
                occurrences.Add(word.ToLower(), 0);
            }

            foreach (var punctuation in punctuationChars)
            {
                text = text.Replace(punctuation, ' ');
            }

            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                foreach (var target in targetWords)
                {
                    if (word.ToLower() == target)
                    {
                        occurrences[target]++;
                        break;
                    }
                }
            }

            foreach (var line in occurrences.OrderByDescending(x => x.Value))
            {
                File.AppendAllLines(@"..\..\..\actualResult.txt", new string[] { $"{line.Key} - {line.Value}" });
            }
        }

        private static char[] GetAllPunctuationChars()
        {
            List<char> punctuationChars = new List<char>();

            for (int i = 0; i < 256; i++)
            {
                if (char.IsPunctuation((char)i))
                {
                    punctuationChars.Add((char)i);
                }
            }

            return punctuationChars.ToArray();
        }
    }
}
