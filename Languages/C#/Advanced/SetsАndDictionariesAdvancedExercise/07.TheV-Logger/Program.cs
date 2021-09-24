using System;
using System.Collections.Generic;

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

                    bool areValid = vloggers.ContainsKey(follower) && vloggers.ContainsKey(following);
                    bool isUnique = follower != following;
                    bool notFollowed = !vloggers[follower].Following.Contains(following);

                    if (areValid)
                    {
                        if (isUnique && notFollowed)
                        {
                            vloggers[follower].Following.Add(following);
                            vloggers[following].Followers.Add(follower);
                        }
                    }
                }
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
        }
    }
}
