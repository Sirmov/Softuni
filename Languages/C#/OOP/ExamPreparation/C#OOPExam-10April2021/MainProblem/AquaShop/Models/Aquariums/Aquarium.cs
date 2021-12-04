using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Fish = new List<IFish>();
            this.Decorations = new List<IDecoration>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count < this.Capacity)
            {
                this.Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string fishes = this.Fish.Count == 0 ? "none" : string.Join(", ", this.Fish.Select(x => x.Name));
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishes}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.Append($"Comfort: {this.Comfort}");
            return sb.ToString();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }
    }
}