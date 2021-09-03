using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submitions = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string username = input.Split("-")[0];
                string language = input.Split("-")[1];

                if (language == "banned")
                {
                    submitions.Remove(username);
                }
                else
                {
                    int points = int.Parse(input.Split("-")[2]);

                    if (!submitions.ContainsKey(username))
                    {
                        submitions.Add(username, 0);
                    }

                    if (points > submitions[username])
                    {
                        submitions[username] = points;
                    }

                    if (!languages.ContainsKey(language))
                    {
                        languages.Add(language, 0);
                    }

                    languages[language]++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Results:");
            foreach (var user in submitions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine($"Submissions: ");
            foreach (var lang in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{lang.Key} - {lang.Value}");
            }
        }
    }
}
