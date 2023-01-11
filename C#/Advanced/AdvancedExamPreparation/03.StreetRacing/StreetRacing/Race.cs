using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new Dictionary<string, Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public Dictionary<string, Car> Participants { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count { get => Participants.Count; }

        public void Add(Car car)
        {
            if (!Participants.ContainsKey(car.LicensePlate))
            {
                if (Count < Capacity && car.HorsePower <= MaxHorsePower)
                {
                    Participants.Add(car.LicensePlate, car);
                }
            }
        }

        public bool Remove(string licensePlate)
        {
            return Participants.Remove(licensePlate);
        }

        public Car FindParticipant(string licensePlate)
        {
            if (Participants.ContainsKey(licensePlate))
            {
                return Participants[licensePlate];
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            return Participants
                .OrderByDescending(c => c.Value.HorsePower)
                .FirstOrDefault().Value;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants)
            {
                sb.AppendLine(car.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
