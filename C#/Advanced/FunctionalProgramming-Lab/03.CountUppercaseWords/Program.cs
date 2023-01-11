using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> isUppercase = word => char.IsUpper(word[0]);
            var uppercaseWords = words.Where(isUppercase);
            Console.WriteLine(string.Join(Environment.NewLine, uppercaseWords));
        }
    }
}
