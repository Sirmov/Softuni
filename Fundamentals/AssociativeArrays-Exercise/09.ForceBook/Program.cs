using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string separator = input.Contains("|") ? " | " : " -> ";

                if (separator == " | ")
                {
                    string side = input.Split(separator)[0];
                    string name = input.Split(separator)[1];

                    if (!sides.Values.Any(x => x.Contains(name)))
                    {
                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new List<string>());
                        }

                        sides[side].Add(name);
                    }
                }
                else
                {
                    string side = input.Split(separator)[1];
                    string name = input.Split(separator)[0];

                    RemoveName(sides, name);

                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new List<string>());
                    }

                    sides[side].Add(name);
                    Console.WriteLine($"{name} joins the {side} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var side in sides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var user in side.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }

        static void RemoveName(Dictionary<string, List<string>> dict, string name)
        {
            foreach (var item in dict)
            {
                item.Value.Remove(name);
            }
        }

        // ####################################################################################################

        //Dictionary<string, string> users = new Dictionary<string, string>();
        //string input = Console.ReadLine();

        //while(input != "Lumpawaroo")
        //{
        //    string separator = input.Contains("|") ? " | " : " -> ";

        //    if (separator == " | ")
        //    {
        //        string side = input.Split(separator)[0];
        //        string name = input.Split(separator)[1];

        //        if (!users.ContainsKey(name))
        //        {
        //            users.Add(name, side);
        //        }
        //    }
        //    else
        //    {
        //        string side = input.Split(separator)[1];
        //        string name = input.Split(separator)[0];

        //        if (users.ContainsKey(name))
        //        {
        //            users[name] = side;
        //        }
        //        else
        //        {
        //            users.Add(name, side);
        //        }
        //        Console.WriteLine($"{name} joins the {side} side!");
        //    }

        //    input = Console.ReadLine();
        //}

        //Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

        //foreach (var (name, side) in users)
        //{
        //    if (!sides.ContainsKey(side))
        //    {
        //        sides.Add(side, new List<string>());
        //    }

        //    sides[side].Add(name);
        //}

        //foreach (var side in sides.OrderByDescending(c => c.Value.Count).ThenBy(n => n.Key))
        //{
        //    if (side.Value.Count > 0)
        //    {
        //        Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
        //        foreach (var user in side.Value.OrderBy(n => n))
        //        {
        //            Console.WriteLine($"! {user}");
        //        }
        //    }
        //}
    }
}
