using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            string[] items = new string[planet.Items.Count];
            planet.Items.CopyTo(items, 0);
            List<string> planetItems = items.ToList();

            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    continue;
                }

                for (int i = 0; i < planetItems.Count; i++)
                {
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(planetItems[i]);
                    planet.Items.Remove(planetItems[i]);
                    planetItems.RemoveAt(i);
                    i--;

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }
            }
        }
    }
}