using System;
using System.Text;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            double total = 0;

            foreach (var item in input)
            {
                StringBuilder num = new StringBuilder();

                foreach (var ch in item)
                {
                    if (char.IsDigit(ch))
                    {
                        num.Append(ch);
                    }
                }

                char firtsLetter = char.Parse(item.Split(num.ToString())[0]);
                char secondLetter = char.Parse(item.Split(num.ToString())[1]);

                double n = double.Parse(num.ToString());

                if (char.IsUpper(firtsLetter))
                {
                    n /= firtsLetter - 64;
                }
                else
                {
                    n *= firtsLetter - 96;
                }

                if (char.IsUpper(secondLetter))
                {
                    n -= secondLetter - 64;
                }
                else
                {
                    n += secondLetter - 96;
                }

                total += n;
            }

            Console.WriteLine($"{total:F2}");
        }
    }
}
