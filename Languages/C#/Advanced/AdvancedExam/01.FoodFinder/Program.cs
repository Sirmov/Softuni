using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Replace(" ", "").ToCharArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Replace(" ", "").ToCharArray());

            Dictionary<string, Dictionary<char, bool>> words = new Dictionary<string, Dictionary<char, bool>>
            {
                { "pear", new Dictionary<char, bool>()},
                { "flour", new Dictionary<char, bool>()},
                { "pork", new Dictionary<char, bool>()},
                { "olive", new Dictionary<char, bool>()}
            };

            foreach (var word in words)
            {
                foreach (var ch in word.Key)
                {
                    word.Value.Add(ch, false);
                }
            }

            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();

                foreach (var word in words)
                {
                    for (int i = 0; i < word.Key.Length; i++)
                    {
                        if (word.Key[i] == vowel || word.Key[i] == consonant)
                        {
                            word.Value[word.Key[i]] = true;
                        }
                    }
                }

                vowels.Enqueue(vowel);
            }

            int found = 0;
            List<string> foundWords = new List<string>();

            foreach (var word in words)
            {
                bool isFound = true;

                foreach (var ch in word.Value)
                {
                    if (!ch.Value)
                    {
                        isFound = false;
                    }
                }

                if (isFound)
                {
                    found++;
                    foundWords.Add(word.Key);
                }
            }


            Console.WriteLine($"Words found: {found}");

            foreach (var item in foundWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
