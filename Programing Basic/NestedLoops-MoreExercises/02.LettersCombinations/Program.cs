using System;

namespace _02.LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());
            int counter = 0;

            int a = Convert.ToInt32(start);
            int b = Convert.ToInt32(end);
            int c = Convert.ToInt32(skip);
            for (int i = a; i <= b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    for (int k = a; k <= b; k++)
                    {
                        if (i != c && j != c && k != c)
                        {
                            Console.Write($"{Convert.ToChar(i)}{Convert.ToChar(j)}{Convert.ToChar(k)} ");
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
