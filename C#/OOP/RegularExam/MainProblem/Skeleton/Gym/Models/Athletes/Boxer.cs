namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, 60)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 15;
        }
    }
}