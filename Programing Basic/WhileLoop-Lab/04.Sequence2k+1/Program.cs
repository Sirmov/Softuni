using System;

namespace _04.Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int currentNum = 1;
            while (currentNum <= num)
            {
                Console.WriteLine(currentNum);
                currentNum = currentNum * 2 + 1;
            }
        }
    }
}
