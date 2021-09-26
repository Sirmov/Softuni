using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] inputArgs = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = inputArgs[0];
                string password = inputArgs[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                input = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] inputArgs = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = inputArgs[0];
                string password = inputArgs[1];
                string username = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!submissions.ContainsKey(username))
                    {
                        submissions.Add(username, new Dictionary<string, int>());
                    }

                    if (!submissions[username].ContainsKey(contest))
                    {
                        submissions[username].Add(contest, -1);
                    }

                    if (points > submissions[username][contest])
                    {
                        submissions[username][contest] = points;
                    }
                }

                input = Console.ReadLine();
            }

            int maxPoints = int.MinValue;
            string maxUser = string.Empty;

            foreach (var user in submissions)
            {
                int totalPoints = user.Value.Sum(x => x.Value);

                if (totalPoints > maxPoints)
                {
                    maxPoints = totalPoints;
                    maxUser = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {maxUser} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in submissions.OrderBy(x => x.Key))
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
