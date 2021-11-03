using System;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            SmartPhone smartPhone = new SmartPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    Console.WriteLine(smartPhone.Call(phoneNumber));
                }
                else if (phoneNumber.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(phoneNumber));
                }
            }

            foreach (var website in websites)
            {
                Console.WriteLine(smartPhone.Browse(website));
            }
        }
    }
}
