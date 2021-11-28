using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies = new List<IBunny>();

        public IReadOnlyCollection<IBunny> Models => this.bunnies.AsReadOnly();

        public void Add(IBunny model)
        {
            this.bunnies.Add(model);
        }

        public IBunny FindByName(string name)
        {
            return this.bunnies.Find(b => b.Name == name);
        }

        public bool Remove(IBunny model)
        {
            return bunnies.Remove(model);
        }
    }
}