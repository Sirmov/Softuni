using System;
using System.Linq;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string reversed = string.Empty;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed += input[i];
                }
                if (input == reversed)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }
        }
    }
}
