using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string output = string.Empty;

            for (int i = 0; i < lenght; i++)
            {
                string input = Console.ReadLine();
                int digits = input.Length;
                int mainDigit = int.Parse(input[0].ToString());
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + digits - 1;
                if (mainDigit == 0)
                {
                    output += " ";
                }
                else
                {
                output += ((char)(letterIndex + 97));
                }
            }

            Console.WriteLine(output);
        }
    }
}
