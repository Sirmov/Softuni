using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnyRepository = new BunnyRepository();
        private EggRepository eggRepository = new EggRepository();
        private int countColoredEggs = 0;

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            this.bunnyRepository.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnyRepository.FindByName(bunnyName);

            if (bunny is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.Dyes.Add(new Dye(power));
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggRepository.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunnies = this.bunnyRepository.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();
            IEgg egg = this.eggRepository.FindByName(eggName);
            IWorkshop workshop = new Workshop();

            if (bunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            for (int i = 0; i < bunnies.Count; i++)
            {
                var bunny = bunnies[i];
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnyRepository.Remove(bunny);
                    bunnies.RemoveAt(i);
                    i--;
                }

                if (egg.IsDone())
                {
                    countColoredEggs++;
                    break;
                }
            }

            if (egg.IsDone())
            {
                return $"Egg {eggName} is done.";
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");

            foreach (var bunny in this.bunnyRepository.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count(d => !d.IsFinished())} not finished");
            }

            return sb.ToString().Trim();
        }
    }
}