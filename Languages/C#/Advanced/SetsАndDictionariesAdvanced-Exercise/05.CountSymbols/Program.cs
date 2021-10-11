using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> symbols = new Dictionary<char, int>();

            foreach (var ch in input)
            {
                if (!symbols.ContainsKey(ch))
                {
                    symbols.Add(ch, 0);
                }

                symbols[ch]++;
            }

            foreach (var symbol in symbols.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
