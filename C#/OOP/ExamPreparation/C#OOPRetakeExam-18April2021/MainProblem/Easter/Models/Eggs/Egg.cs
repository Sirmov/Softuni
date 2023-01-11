using System;
using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private int energyRequired;
        private string name;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;

            private set
            {
                this.energyRequired = value < 0 ? 0 : value;
            }
        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone() => this.EnergyRequired == 0;
    }
}