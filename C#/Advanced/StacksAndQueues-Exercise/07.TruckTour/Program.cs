using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumpsCount = int.Parse(Console.ReadLine());
            Queue<PetrolPump> pumps = new Queue<PetrolPump>();

            for (int i = 0; i < petrolPumpsCount; i++)
            {
                int[] pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(new PetrolPump(pump[0], pump[1]));
            }

            for (int i = 0; i < petrolPumpsCount; i++)
            {
                if (i > 0)
                {
                    pumps.Enqueue(pumps.Dequeue());
                }

                Queue<PetrolPump> pumpsCopy = new Queue<PetrolPump>(pumps);
                int fuelTank = 0;
                while (pumpsCopy.Count > 0)
                {
                    fuelTank += pumpsCopy.Peek().Fuel;

                    if (fuelTank >= pumpsCopy.Peek().Distance)
                    {
                        fuelTank -= pumpsCopy.Peek().Distance;
                        pumpsCopy.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }

                if (pumpsCopy.Count == 0)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
    
    class PetrolPump
    {
        public int Fuel { get; set; }
        public int Distance { get; set; }

        public PetrolPump(int fuel, int distance)
        {
            Fuel = fuel;
            Distance = distance;
        }
    }
}
