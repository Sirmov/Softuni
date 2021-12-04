using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository = new DecorationRepository();
        private List<IAquarium> aquariums = new List<IAquarium>();

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorationRepository.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = this.aquariums.Find(a => a.Name == aquariumName);
            if (fishType == "FreshwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium")
            {
                return "Water not suitable.";
            }
            else if (fishType == "SaltwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            {
                return "Water not suitable.";
            }
            else
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.Find(a => a.Name == aquariumName);
            decimal price = 0.0m;

            foreach (var fish in aquarium.Fish)
            {
                price += fish.Price;
            }
            foreach (var decoration in aquarium.Decorations)
            {
                price += decoration.Price;
            }

            return $"The value of Aquarium {aquariumName} is {price:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.Find(a => a.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorationRepository.FindByType(decorationType);

            if (decoration is null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            IAquarium aquarium = this.aquariums.Find(a => a.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            this.decorationRepository.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}