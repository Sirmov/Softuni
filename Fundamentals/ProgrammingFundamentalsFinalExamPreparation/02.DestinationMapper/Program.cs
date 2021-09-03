using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1");
            List<string> destinations = new List<string>();
            string input = Console.ReadLine();

            foreach (Match match in regex.Matches(input))
            {
                destinations.Add(match.Groups["destination"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");

            int travelPoints = 0;

            foreach (var destination in destinations)
            {
                travelPoints += destination.Length;
            }

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
