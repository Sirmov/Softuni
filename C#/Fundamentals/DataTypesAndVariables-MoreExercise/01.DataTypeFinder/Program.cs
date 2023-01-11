using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                bool isInteger = int.TryParse(input, out int resultA);
                bool isFloatingPoint = double.TryParse(input, out double resultB);
                bool isCharacter = char.TryParse(input, out char resultC);
                bool isBoolean = bool.TryParse(input, out bool resultD);
                bool isString = isInteger == false && isFloatingPoint == false && isCharacter == false && isBoolean == false;

                string result = string.Empty;
                if (isInteger)
                {
                    result = "integer";
                }
                else if (isFloatingPoint)
                {
                    result = "floating point";
                }
                else if (isCharacter)
                {
                    result = "character";
                }
                else if (isBoolean)
                {
                    result = "boolean";
                }
                else if (isString)
                {
                    result = "string";
                }

                Console.WriteLine($"{input} is {result} type");

                input = Console.ReadLine();
            }
        }
    }
}
