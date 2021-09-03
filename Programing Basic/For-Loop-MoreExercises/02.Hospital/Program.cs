using System;

namespace _02.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int doctors = 7;
            int untreatedPatients = 0;
            int treatedPatients = 0;
            int patients;
            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0 && untreatedPatients > treatedPatients)
                {
                    doctors++;
                }
                patients = int.Parse(Console.ReadLine());
                if (doctors == patients)
                {
                    treatedPatients += patients;
                }
                else if (doctors > patients)
                {
                    treatedPatients += patients;
                }
                else if (doctors < patients)
                {
                    treatedPatients += doctors;
                    untreatedPatients += patients - doctors;
                }
            }
            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
