using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArgs = command.Split();
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);
                string town = commandArgs[2];

                people.Add(new Person(name, age, town));

                command = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            int countOfMatches = 1;

            for (int i = 0; i < people.Count; i++)
            {
                if (i == index)
                {
                    continue;
                }
                
                if (people[index].CompareTo(people[i]) == 0)
                {
                    countOfMatches++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {people.Count - countOfMatches} {people.Count}");
            }
        }
    }
}
