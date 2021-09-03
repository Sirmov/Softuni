using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> users = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] inputArgs = input.Split(" -> ");
                string username = inputArgs[0];
                string contest = inputArgs[1];
                int points = int.Parse(inputArgs[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new Dictionary<string, int>());
                }

                if (!contests[contest].ContainsKey(username))
                {
                    contests[contest].Add(username, 0);
                }

                if (points > contests[contest][username])
                {
                    contests[contest][username] = points;
                }

                if (!users.ContainsKey(username))
                {
                    users.Add(username, 0);
                }

                input = Console.ReadLine();
            }

            foreach (var contest in contests)
            {
                foreach (var user in contest.Value)
                {
                    users[user.Key] += user.Value;
                }
            }

            int i = 1;

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                i = 1;
                foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{i}. {user.Key} <::> {user.Value}");
                    i++;
                }
            }

            i = 1;

            Console.WriteLine("Individual standings:");
            foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{i}. {user.Key} -> {user.Value}");
                i++;
            }
        }
    }
}
