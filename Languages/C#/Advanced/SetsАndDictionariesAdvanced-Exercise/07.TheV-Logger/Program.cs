using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                if (command.Contains("joined"))
                {
                    string name = command.Split(" joined ")[0];

                    if (!vloggers.ContainsKey(name))
                    {
                        vloggers.Add(name, new Vlogger(name));
                    }
                }
                else if (command.Contains("followed"))
                {
                    string[] line = command.Split(" followed ");
                    string follower = line[0];
                    string following = line[1];

                    if (vloggers.ContainsKey(follower) && vloggers.ContainsKey(following))
                    {
                        if (follower != following && !vloggers[follower].Following.Contains(following))
                        {
                            vloggers[follower].Following.Add(following);
                            vloggers[following].Followers.Add(follower);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int num = 1;
            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count))
            {
                if (num == 1)
                {
                    Console.WriteLine($"1. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

                    foreach (var follower in vlogger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                else
                {
                    Console.WriteLine($"{num}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                }

                num++;
            }
        }
    }

    class Vlogger
    {
        public string Name { get; set; }
        public List<string> Following { get; set; }
        public List<string> Followers { get; set; }

        public Vlogger(string name)
        {
            Name = name;
            Following = new List<string>();
            Followers = new List<string>();
        }
    }
}
