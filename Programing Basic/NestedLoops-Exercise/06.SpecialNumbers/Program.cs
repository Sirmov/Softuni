using System;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1111; i <= 9999; i++)
            {
                string str = i.ToString();
                char firstChar = str[0];
                char secondChar = str[1];
                char thirdChar = str[2];
                char fourthChar = str[3];
                int firstDigit = int.Parse(firstChar.ToString());
                int secondDigit = int.Parse(secondChar.ToString());
                int thirdDigit = int.Parse(thirdChar.ToString());
                int fourthDigit = int.Parse(fourthChar.ToString());
                if (firstDigit == 0 || secondDigit == 0 || thirdDigit == 0 || fourthDigit == 0)
                {
                    continue;
                }
                if (n % firstDigit == 0 && n % secondDigit == 0 && n % thirdDigit == 0 && n % fourthDigit == 0)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
