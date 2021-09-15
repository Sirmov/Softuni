using System;

namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int counter = 1;
            int currNum = 1;
            bool flag = false;
            for (int r = 0; r < num; r++)
            {
                for (int i = 0; i < counter; i++)
                {
                    if (currNum > num)
                    {
                        flag = true;
                        break;
                    }
                    Console.Write($"{currNum} ");
                    currNum++;
                }
                if (flag)
                {
                    break;
                }
                Console.WriteLine();
                counter++;
            }
        }
    }
}
