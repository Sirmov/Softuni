using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double headsets = 0;
            double mice = 0;
            double keyboards = 0;
            double displays = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headsets++;
                }
                if (i % 3 == 0)
                {
                    mice++;
                }
                if (i % 6 == 0)
                {
                    keyboards++;
                }
                if (i % 12 == 0)
                {
                    displays++;
                }
            }

            double totalExpenses = headsets * headsetPrice + mice * mousePrice + keyboards * keyboardPrice + displays * displayPrice;
            Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");
        }
    }
}
