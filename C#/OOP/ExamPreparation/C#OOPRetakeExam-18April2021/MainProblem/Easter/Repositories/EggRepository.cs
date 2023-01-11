using System.Collections.Generic;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs = new List<IEgg>();

        public IReadOnlyCollection<IEgg> Models => this.eggs.AsReadOnly();

        public void Add(IEgg model)
        {
            this.eggs.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return this.eggs.Find(e => e.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return eggs.Remove(model);
        }
    }
}