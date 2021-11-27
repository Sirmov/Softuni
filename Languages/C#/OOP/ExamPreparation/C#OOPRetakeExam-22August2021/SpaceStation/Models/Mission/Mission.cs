using System.Collections.Generic;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                foreach (var astronaut in astronauts)
                {
                    if (!astronaut.CanBreath)
                    {
                        continue;
                    }

                    foreach (var item in planet.Items)
                    {
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);

                        if (!astronaut.CanBreath)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}