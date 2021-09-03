using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(100f != 100d);
            Dictionary<string, int[]> followers = new Dictionary<string, int[]>();
            string command = Console.ReadLine();

            while (command != "Log out")
            {
                string[] commandArgs = command.Split(": ");
                string operation = commandArgs[0];
                string username = commandArgs[1];

                if (operation == "New follower")
                {
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new int[] { 0, 0 });
                    }
                }
                else if (operation == "Like")
                {
                    int count = int.Parse(commandArgs[2]);

                    if (followers.ContainsKey(username))
                    {
                        followers[username][0] += count;
                    }
                    else
                    {
                        followers.Add(username, new int[] { count, 0 });
                    }
                }
                else if (operation == "Comment")
                {
                    if (followers.ContainsKey(username))
                    {
                        followers[username][1]++;
                    }
                    else
                    {
                        followers.Add(username, new int[] { 0, 1 });
                    }
                }
                else if (operation == "Blocked")
                {
                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{followers.Count} followers");
            foreach (var follower in followers.OrderByDescending(x => x.Value.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{follower.Key}: {follower.Value.Sum()}");
            }
        }
    }
}
