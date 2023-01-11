namespace _03.Raiding
{
    internal class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}