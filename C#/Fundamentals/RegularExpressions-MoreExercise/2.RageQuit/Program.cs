using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<str>[^\d]+)(?<times>[0-9]{1,2})");
            StringBuilder result = new StringBuilder();
            List<char> symbols = new List<char>();
            string input = Console.ReadLine();

            foreach (Match match in regex.Matches(input))
            {
                string str = "";

                foreach (var ch in match.Groups["str"].Value)
                {
                    str += char.ToUpper(ch);
                }

                for (int i = 0; i < int.Parse(match.Groups["times"].Value); i++)
                {
                    result.Append(str);
                }
            }

            Console.WriteLine($"Unique symbols used: {result.ToString().Distinct().Count()}");
            Console.WriteLine(result);
        }
    }
}
