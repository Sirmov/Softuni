using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex email = new Regex(@"(^|(?<=\s))[A-Za-z0-9][\w\.\-_]+[\w]@[\w][\w\-]+[\w](\.[\w][\w\-]+)+");
            string input = Console.ReadLine();

            foreach (Match match in email.Matches(input))
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
