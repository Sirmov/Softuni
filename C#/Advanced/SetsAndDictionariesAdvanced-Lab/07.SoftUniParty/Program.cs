using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> people = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    VIP.Add(input);
                }
                else
                {
                    people.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    VIP.Remove(input);
                }
                else
                {
                    people.Remove(input);
                }
            }

            Console.WriteLine(VIP.Count + people.Count);
            foreach (var person in VIP)
            {
                Console.WriteLine(person);
            }
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
