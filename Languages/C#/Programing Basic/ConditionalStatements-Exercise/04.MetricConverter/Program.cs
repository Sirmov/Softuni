using System;

namespace _04.MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Може да се оптимизира с *= и /=
            double num = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();
            if (inputUnit == "m")
            {
                if (outputUnit == "m")
                {
                    num = num;
                }
                else if (outputUnit == "mm")
                {
                    num = num * 1000;
                }
                else if (outputUnit == "cm")
                {
                    num = num * 100;
                }
            }
            else if (inputUnit == "mm")
            {
                if (outputUnit == "m")
                {
                    num = num / 1000;
                }
                else if (outputUnit == "mm")
                {
                    num = num;
                }
                else if (outputUnit == "cm")
                {
                    num = num / 10;
                }
            }
            else if (inputUnit == "cm")
            {
                if (outputUnit == "m")
                {
                    num = num / 100;
                }
                else if (outputUnit == "mm")
                {
                    num = num * 10;
                }
                else if (outputUnit == "cm")
                {
                    num = num;
                }
            }
            Console.WriteLine($"{num:F3}");
        }
    }
}
