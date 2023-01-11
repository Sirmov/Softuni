using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenlightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int passed = 0;
            Queue<string> trafic = new Queue<string>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "green")
                {
                    int timer = greenlightDuration;
                    while (timer > 0 && trafic.Count > 0)
                    {
                        string car = trafic.Peek();
                        if (car.Length <= timer)
                        {
                            timer -= car.Length;
                            trafic.Dequeue();
                            passed++;
                        }
                        else
                        {
                            car = car.Remove(0, timer);
                            timer = 0;
                            if (car.Length <= freeWindowDuration)
                            {
                                trafic.Dequeue();
                                passed++;
                            }
                            else
                            {
                                car = car.Remove(0, freeWindowDuration);
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{trafic.Peek()} was hit at {car[0]}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    trafic.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
