using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            ValidatePassword(password);
        }

        static void ValidatePassword(string password)
        {
            int charecters = password.Length;
            int letters = 0;
            int digits = 0;
            bool isSymbols = false;

            for (int i = 0; i < password.Length; i++)
            {
                int curr = (int) password[i];

                if (curr >= 65 && curr <= 90 || curr >= 97 && curr <= 122)
                {
                    letters++;
                }
                else if (curr >= 48 && curr <= 57)
                {
                    digits++;
                }
                else
                {
                    isSymbols = true;
                }
            }
            
            CheckRules(charecters, letters, digits, isSymbols);
        }

        static void CheckRules(int charecters, int letters, int digits, bool isSymbols)
        {
            bool isValid = true;
            
            if (charecters < 6 || charecters > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (isSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (digits < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
