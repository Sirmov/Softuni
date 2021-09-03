using System;
using System.Text;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arguments = Console.ReadLine().Split();
            string str1 = arguments[0];
            string str2 = arguments[1];
            int n = str1.Length == str2.Length? str1.Length : Math.Min(str1.Length, str2.Length);
            int total = 0;

            for (int i = 0; i < n; i++)
            {
                total += str1[i] * str2[i];
            }

            if (str1.Length > str2.Length)
            {
                for (int i = 0; i < str1.Length - n; i++)
                {
                    total += str1[str1.Length - 1 - i] - 0;
                }
            }
            else if (str2.Length > str1.Length)
            {
                for (int i = 0; i < str2.Length - n; i++)
                {
                    total += str2[str2.Length - 1 - i] - 0;
                }
            }

            Console.WriteLine(total);
        }
    }
}
