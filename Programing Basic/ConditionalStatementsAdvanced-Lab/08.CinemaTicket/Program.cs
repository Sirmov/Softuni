using System;

namespace _08.CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Monday Tuesday Wednesday Thursday    Friday Saturday    Sunday
            //12      12        14        14        12      16          16
            string dayOfWeek = Console.ReadLine();
            switch (dayOfWeek)
            {
                case "Monday":
                    Console.WriteLine("12");
                    break;
                case "Tuesday":
                    Console.WriteLine("12");
                    break;
                case "Wednesday":
                    Console.WriteLine("14");
                    break;
                case "Thursday":
                    Console.WriteLine("14");
                    break;
                case "Friday":
                    Console.WriteLine("12");
                    break;
                case "Saturday":
                    Console.WriteLine("16");
                    break;
                case "Sunday":
                    Console.WriteLine("16");
                    break;
            }
        }
    }
}
