using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double studentTickets = 0;
            double kidTickets = 0;
            double standardTickets = 0;
            double totalTickets = 0;

            string filmName = Console.ReadLine();
            while (filmName != "Finish")
            {
                double seats = double.Parse(Console.ReadLine());
                string currentTicket = "";
                double currentSeats = 0;
                while (currentTicket != "End")
                {
                    if (currentSeats == seats)
                    {
                        break;
                    }
                    currentTicket = Console.ReadLine();
                    if (currentTicket == "student")
                    {
                        studentTickets++;
                        currentSeats++;
                        totalTickets++;
                    }
                    else if (currentTicket == "kid")
                    {
                        kidTickets++;
                        currentSeats++;
                        totalTickets++;
                    }
                    else if (currentTicket == "standard")
                    {
                        standardTickets++;
                        currentSeats++;
                        totalTickets++;
                    }
                }
                Console.WriteLine($"{filmName} - {currentSeats / seats * 100:F2}% full.");
                filmName = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTickets / totalTickets * 100:F2}% student tickets.");
            Console.WriteLine($"{standardTickets / totalTickets * 100:F2}% standard tickets.");
            Console.WriteLine($"{kidTickets / totalTickets * 100:F2}% kids tickets.");
        }
    }
}
