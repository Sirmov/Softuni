using System;

namespace _08.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinute = int.Parse(Console.ReadLine());

            int examMinutes = examMinute + examHour * 60;
            int arriveMinutes = arriveMinute + arriveHour * 60;

            if (arriveMinutes == examMinutes || arriveMinutes >= (examMinutes - 30) && arriveMinutes <= examMinutes)
            {
                Console.WriteLine("On Time");
            }
            else if (arriveMinutes > examMinutes)
            {
                Console.WriteLine("Late");
            }
            else
            {
                Console.WriteLine("Early");
            }

            int hoursDifference = Math.Abs(examMinutes - arriveMinutes) / 60;
            int minutesDifference = Math.Abs(examMinutes - arriveMinutes) % 60;

            if (arriveMinutes != examMinutes)
            {
                if (hoursDifference == 0)
                {
                    if (examMinutes > arriveMinutes)
                    {
                        Console.WriteLine($"{minutesDifference} minutes before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{minutesDifference} minutes after the start");
                    }
                }
                else
                {
                    if (examMinutes > arriveMinutes)
                    {
                        Console.WriteLine($"{hoursDifference}:{minutesDifference:D2} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hoursDifference}:{minutesDifference:D2} hours after the start");
                    }
                }
            }
        }
    }
}
