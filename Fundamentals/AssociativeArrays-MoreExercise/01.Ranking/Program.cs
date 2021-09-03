using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                contests.Add(input.Split(":")[0], input.Split(":")[1]);
                input = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();

            while (command != "end of submissions")
            {
                string[] commandArgs = command.Split("=>");
                string contest = commandArgs[0];
                string password = commandArgs[1];
                string username = commandArgs[2];
                int points = int.Parse(commandArgs[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        if (!users.ContainsKey(username))
                        {
                            users.Add(username, new Dictionary<string, int>());
                        }

                        if (!users[username].ContainsKey(contest))
                        {
                            users[username].Add(contest, 0);
                        }

                        if (points > users[username][contest])
                        {
                            users[username][contest] = points;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            string bestUser = "";
            int bestScore = int.MinValue;

            foreach (var user in users)
            {
                if (user.Value.Values.Sum() > bestScore)
                {
                    bestScore = user.Value.Values.Sum();
                    bestUser = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestScore} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
