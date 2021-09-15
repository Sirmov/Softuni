using System;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[|](?<name>[A-Z]{4,})[|]:#(?<title>[A-Za-z]+ [A-Za-z]+)#");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string user = Console.ReadLine();

                if (regex.IsMatch(user))
                {
                    Match match = regex.Match(user);
                    string name = match.Groups["name"].Value;
                    string title = match.Groups["title"].Value;
                    Console.WriteLine($"{name}, The {title}");
                    Console.WriteLine($">> Strength: {name.Length}");
                    Console.WriteLine($">> Armor: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
