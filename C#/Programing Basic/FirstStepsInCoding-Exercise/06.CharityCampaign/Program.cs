using System;

namespace _06.CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakesFor1Day = int.Parse(Console.ReadLine());
            int wafflesFor1Day = int.Parse(Console.ReadLine());
            int pancakesFor1Day = int.Parse(Console.ReadLine());
            double cakes = bakers * cakesFor1Day * 45;
            double waffles = bakers * wafflesFor1Day * 5.80;
            double pancakes = bakers * pancakesFor1Day * 3.20;
            double sum = (cakes + waffles + pancakes) * days;
            sum -= sum / 8;
            Console.WriteLine(sum);
        }
    }
}
