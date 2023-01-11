using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([^@,\-!:>]+)?@(?<planet>[A-z]+)([^@,\-!:>]+)?:(?<population>[0-9]+)!(?<type>[A-Z])!([^@,\-!:>]+)?->(?<count>[0-9]+)([^@,\-!:>]+)?");
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int key = 0;

                foreach (var ch in input)
                {
                    if (ch == 's' || ch == 'a' || ch == 't' || ch == 'r' ||
                        ch == 'S' || ch == 'A' || ch == 'T' || ch == 'R')
                    {
                        key++;
                    }
                }

                StringBuilder decrypted = new StringBuilder();

                foreach (var ch in input)
                {
                    decrypted.Append((char)(ch - key));
                }

                if (regex.IsMatch(decrypted.ToString()))
                {
                    Match match = regex.Match(decrypted.ToString());
                    string type = match.Groups["type"].Value;
                    string planet = match.Groups["planet"].Value;
                    if (type == "A")
                    {
                        attacked.Add(planet);
                    }
                    else if (type == "D")
                    {
                        destroyed.Add(planet);
                    }
                }
            }

            attacked.Sort();
            destroyed.Sort();

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var item in attacked)
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var item in destroyed)
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
