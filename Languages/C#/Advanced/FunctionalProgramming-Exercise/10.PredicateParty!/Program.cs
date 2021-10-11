using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();
            while (command != "Party!")
            {
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];
                string criteria = commandArgs[1];
                Predicate<string> predicate = null;

                if (criteria == "StartsWith")
                {
                    string target = commandArgs[2];
                    predicate = s => s.StartsWith(target);
                }
                else if (criteria == "EndsWith")
                {
                    string target = commandArgs[2];
                    predicate = s => s.EndsWith(target);
                }
                else if (criteria == "Length")
                {
                    int target = int.Parse(commandArgs[2]);
                    predicate = s => s.Length == target;
                }

                if (operation == "Remove")
                {
                    names.RemoveAll(x => predicate(x));
                }
                else if (operation == "Double")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (predicate(names[i]))
                        {
                            names.Insert(i + 1, names[i]);
                            i++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
        }
    }
}
