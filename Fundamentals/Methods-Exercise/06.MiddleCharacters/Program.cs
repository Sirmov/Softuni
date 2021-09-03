using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(GetMiddle(input));
        }

        static string GetMiddle(string input)
        {
            bool isEven = input.Length % 2 == 0;
            string result = string.Empty;

            if (isEven)
            {
                result += input[input.Length / 2 - 1];
                result += input[input.Length / 2];
            }
            else
            {
                result += input[input.Length / 2];
            }

            return result;
        }
    }
}
