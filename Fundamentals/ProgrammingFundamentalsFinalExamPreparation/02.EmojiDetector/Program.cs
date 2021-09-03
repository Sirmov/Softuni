using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1");
            List<string> cool = new List<string>();
            string input = Console.ReadLine();
            BigInteger coolTreshold = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    coolTreshold *= int.Parse(input[i].ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{regex.Matches(input).Count} emojis found in the text. The cool ones are:");

            foreach (Match match in regex.Matches(input))
            {
                string emoji = match.Groups["emoji"].Value;
                long coolness = 0;

                for (int i = 0; i < emoji.Length; i++)
                {
                    coolness += emoji[i];
                }

                if (coolness >= coolTreshold)
                {
                    cool.Add(match.Value);
                }
            }

            foreach (var emoji in cool)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
