using System;

namespace _02.RectangleOfNxNStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
