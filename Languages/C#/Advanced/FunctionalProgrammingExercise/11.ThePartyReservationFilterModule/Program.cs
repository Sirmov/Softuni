using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ").ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command = Console.ReadLine();
            while (command != "Print")
            {
                string[] commandArgs = command.Split(';');
                string operation = commandArgs[0];
                string criteria = commandArgs[1];
                string key = null;  

                Predicate<string> predicate = null;

                if (criteria == "Starts with")
                {
                    string target = commandArgs[2];
                    predicate = s => s.StartsWith(target);
                    key = target;
                }
                else if (criteria == "Ends with")
                {
                    string target = commandArgs[2];
                    predicate = s => s.EndsWith(target);
                    key = target;
                }
                else if (criteria == "Contains")
                {
                    string target = commandArgs[2];
                    predicate = s => s.Contains(target);
                    key = target;
                }
                else if (criteria == "Length")
                {
                    int target = int.Parse(commandArgs[2]);
                    predicate = s => s.Length == target;
                    key = target.ToString();
                }

                if (operation == "Add filter")
                {
                    filters.Add(key, predicate);
                }
                else if (operation == "Remove filter")
                {
                    filters.Remove(key);
                }

                command = Console.ReadLine();
            }

            foreach (var name in names)
            {
                bool isValid = true;

                foreach (var filter in filters)
                {
                    if (filter.Value(name))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    Console.Write(name + " ");
                }
            }
        }
    }
}
