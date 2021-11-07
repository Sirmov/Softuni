namespace _03.Raiding
{
    internal class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}