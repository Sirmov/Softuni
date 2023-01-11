using System;
using System.Linq;

namespace _03.Telephony
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split();

            SmartPhone smartPhone = new SmartPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Any(n => !char.IsDigit(n)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (phoneNumber.Length == 10)
                {
                    smartPhone.Call(phoneNumber);
                }
                else if (phoneNumber.Length == 7)
                {
                    stationaryPhone.Call(phoneNumber);
                }
            }

            foreach (var website in websites)
            {
                if (website.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                smartPhone.Browse(website);
            }
        }
    }
}