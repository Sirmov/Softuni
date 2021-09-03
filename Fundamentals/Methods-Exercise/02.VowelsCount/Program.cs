using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(GetVowels(input));
        }

        static int GetVowels(string str)
        {
            int sum = 0;
            
            for (int i = 0; i < str.Length; i++)
            {
                if ("aeiouAEIOU".IndexOf(str[i]) >= 0)
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}
