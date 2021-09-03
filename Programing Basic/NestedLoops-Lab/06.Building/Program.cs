using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            int currFloor = floors;
            int currRoom = 0;
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (currFloor == floors)
                    {
                        Console.Write($"L{currFloor}{currRoom} ");
                    }
                    else if (currFloor % 2 == 0)
                    {
                        Console.Write($"O{currFloor}{currRoom} ");
                    }
                    else
                    {
                        Console.Write($"A{currFloor}{currRoom} ");
                    }
                    currRoom++;
                }
                Console.WriteLine();
                currRoom = 0;
                currFloor--;
            }
        }
    }
}
