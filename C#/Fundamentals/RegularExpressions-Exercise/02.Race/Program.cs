using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = new Dictionary<string, int>();
            string[] str = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in str)
            {
                if (!racers.ContainsKey(item))
                {
                    racers.Add(item, 0);
                }
            }

            Regex regex = new Regex(@"[\w\d]");
            string input = Console.ReadLine();

            while (input != "end of race")
            {
                if (regex.IsMatch(input))
                {
                    MatchCollection matches = regex.Matches(input);
                    StringBuilder name = new StringBuilder();
                    int distance = 0;

                    foreach (Match match in matches)
                    {
                        if (char.IsLetter(char.Parse(match.Value)))
                        {
                            name.Append(match.Value);
                        }
                        else
                        {
                            distance += int.Parse(match.Value);
                        }
                    }

                    if (racers.ContainsKey(name.ToString()))
                    {
                        racers[name.ToString()] += distance;
                    }
                }

                input = Console.ReadLine();
            }

            int i = 1;
            foreach (var racer in racers.OrderByDescending(x => x.Value).Take(3))
            {
                if (i == 1)
                {
                    Console.WriteLine($"1st place: {racer.Key}");
                }
                else if (i == 2)
                {
                    Console.WriteLine($"2nd place: {racer.Key}");
                }
                else
                {
                    Console.WriteLine($"3rd place: {racer.Key}");
                }

                i++;
            }
        }
    }
}
