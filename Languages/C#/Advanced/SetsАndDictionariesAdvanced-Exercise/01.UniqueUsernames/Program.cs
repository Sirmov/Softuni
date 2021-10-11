using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesCount = int.Parse(Console.ReadLine());
            Dictionary<string, int> names = new Dictionary<string, int>();

            for (int i = 0; i < namesCount; i++)
            {
                string name = Console.ReadLine();

                if (!names.ContainsKey(name))
                {
                    names.Add(name, 0);
                }

                names[name]++;
            }

            foreach (var name in names)
            {
                Console.WriteLine(name.Key);
            }
        }
    }
}
