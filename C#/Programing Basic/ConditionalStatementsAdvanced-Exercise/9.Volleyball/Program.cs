using System;

namespace _9.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първият ред съдържа думата "leap"(високосна година) или "normal"(невисокосна).
            //•	Вторият ред съдържа цялото число p – брой празници в годината(които не са събота и неделя).
            //•	Третият ред съдържа цялото число h – брой уикенди, в които Влади си пътува до родния град.
            string yearType = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double hometownWeekedns = double.Parse(Console.ReadLine());
            
            double sofiaWeekends = (48 - hometownWeekedns);
            double sofiaGames = sofiaWeekends * 3 / 4;
            double hometownGames = hometownWeekedns;
            sofiaGames += holidays * 2 / 3;
            double totalGames = sofiaGames + hometownGames;
            
            if (yearType == "leap")
            {
                totalGames += totalGames * 0.15;
            }
            Console.WriteLine($"{Math.Floor(totalGames)}");
        }
    }
}
