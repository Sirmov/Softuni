using System;

namespace _03.Raiding
{
    internal class HeroFactory
    {
        private string name;
        private string type;

        public HeroFactory(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public BaseHero CreateHero()
        {
            if (this.type == "Druid")
            {
                return new Druid(name);
            }
            else if (this.type == "Paladin")
            {
                return new Paladin(name);
            }
            else if (this.type == "Rogue")
            {
                return new Rogue(name);
            }
            else if (this.type == "Warrior")
            {
                return new Warrior(name);
            }

            throw new InvalidOperationException("Invalid hero!");
        }
    }
}