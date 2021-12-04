namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            Aquarium aquarium = new Aquarium("Ocean", 50);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void NameShouldThrowExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 50));
        }

        [Test]
        public void CapacityShouldBeNonNegative()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Ocean", -1));
        }

        [Test]
        public void AddShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("Ocean", 50);
            Fish fish = new Fish("Gosho");
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenTankIsFull()
        {
            Aquarium aquarium = new Aquarium("Ocean", 0);
            Fish fish = new Fish("Gosho");
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("Ocean", 50);
            Fish fish = new Fish("Gosho");
            aquarium.Add(fish);
            aquarium.RemoveFish("Gosho");
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void SellFishShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("Ocean", 50);
            Fish fish = new Fish("Gosho");
            aquarium.Add(fish);
            Assert.AreSame(fish, aquarium.SellFish("Gosho"));
        }

        [Test]
        public void ReportShouldWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("Ocean", 50);
            Fish fish1 = new Fish("Gosho");
            Fish fish2 = new Fish("Pesho");
            Fish fish3 = new Fish("Aleko");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            string expected = $"Fish available at Ocean: Gosho, Pesho, Aleko";
            Assert.AreEqual(expected, aquarium.Report());
        }
    }
}