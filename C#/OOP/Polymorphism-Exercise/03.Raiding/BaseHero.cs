namespace _03.Raiding
{
    internal abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public int Power { get; set; }

        public abstract string CastAbility();
    }
}