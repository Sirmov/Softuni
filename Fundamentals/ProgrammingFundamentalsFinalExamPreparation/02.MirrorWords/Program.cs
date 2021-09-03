using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([@#])(?<first>[A-Za-z]{3,})\1\1(?<second>[A-Za-z]{3,})\1");
            List<string> mirrors = new List<string>();
            string input = Console.ReadLine();

            if (regex.IsMatch(input))
            {
                Console.WriteLine($"{regex.Matches(input).Count} word pairs found!");

                foreach (Match match in regex.Matches(input))
                {
                    string first = match.Groups["first"].Value;
                    string second = match.Groups["second"].Value;

                    char[] temp = match.Groups["second"].Value.ToCharArray();
                    Array.Reverse(temp);
                    string reversed = new string(temp);

                    if (reversed == first)
                    {
                        mirrors.Add($"{first} <=> {second}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirrors.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrors));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
