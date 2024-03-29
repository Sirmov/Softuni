﻿using System.Collections.Generic;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models = new List<IAstronaut>();

        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.models.Find(m => m.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return this.models.Remove(model);
        }
    }
}