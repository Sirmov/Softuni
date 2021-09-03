using System;
using System.Collections.Generic;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validUsernames = new List<string>();

            foreach (var user in usernames)
            {
                bool isValid = true;

                if (user.Length < 3 || user.Length > 16)
                {
                    isValid = false;
                }

                foreach (var letter in user)
                {
                    if (!char.IsLetterOrDigit(letter) && letter != '-' && letter != '_')
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    validUsernames.Add(user);
                }
            }

            Console.WriteLine($"{string.Join("\r\n", validUsernames)}");
        }
    }
}
