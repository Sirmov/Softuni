using System;
using System.Text.RegularExpressions;

namespace _1.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[@#\$\^]{6,10}");
            string[] tickets = Console.ReadLine().Split(new string[] { " ", "," },StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    string left = ticket.Substring(0, 10);
                    string right = ticket.Substring(10, 10);

                    if (regex.IsMatch(left) && regex.IsMatch(right))
                    {
                        Match leftMatch = regex.Match(left);
                        Match rightMatch = regex.Match(right);
                        int minLen = Math.Min(leftMatch.Length, rightMatch.Length);

                        if (leftMatch.Length == rightMatch.Length && leftMatch.ToString()[0] == rightMatch.ToString()[0])
                        {
                            if (leftMatch.Length < 10)
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {leftMatch.Length}{leftMatch.ToString()[0]}");
                            }
                            else if (leftMatch.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - {leftMatch.Length}{leftMatch.ToString()[0]} Jackpot!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
