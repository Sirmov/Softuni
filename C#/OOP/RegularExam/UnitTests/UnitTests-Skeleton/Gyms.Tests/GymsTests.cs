using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void ConstructorShouldIntializeCollection()
        {
            Gym gym = new Gym("Respect", 15);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void ConstructorShouldSetName()
        {
            Gym gym = new Gym("Respect", 15);
            Assert.AreEqual("Respect", gym.Name);
        }

        [Test]
        public void ConstructorShouldSetCapacity()
        {
            Gym gym = new Gym("Respect", 15);
            Assert.AreEqual(15, gym.Capacity);
        }

        [Test]
        public void NameShouldNotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 15));
        }

        [Test]
        public void CapacityShouldBeNonNegative()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Respect", -1));
        }

        [Test]
        public void CountShouldWorkCorrectly()
        {
            Gym gym = new Gym("Respect", 15);

            for (int i = 0; i < 15; i++)
            {
                gym.AddAthlete(new Athlete(i.ToString()));
            }

            Assert.AreEqual(15, gym.Count);
        }

        [Test]
        public void AddAthleteShouldWorkCorrectly()
        {
            Gym gym = new Gym("Respect", 15);
            Athlete athlete = new Athlete("Nikola Sirmov");
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void AddAthleteShoulThrowWhenGymIsFull()
        {
            Gym gym = new Gym("Respect", 1);
            Athlete athlete = new Athlete("Nikola Sirmov");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }

        [Test]
        public void RemoveAthleteShouldWorkCorrectly()
        {
            Gym gym = new Gym("Respect", 15);
            Athlete athlete = new Athlete("Nikola Sirmov");
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Nikola Sirmov");
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void RemoveShouldThrowWhenAthleteDoesNotExist()
        {
            Gym gym = new Gym("Respect", 15);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Nikola Sirmov"));
        }

        [Test]
        public void InjureAthleteShouldWorkCorrectly()
        {
            Gym gym = new Gym("Respect", 15);
            Athlete athlete = new Athlete("Nikola Sirmov");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Nikola Sirmov");
            Assert.IsTrue(athlete.IsInjured);
        }

        [Test]
        public void InjureAthleteShoulThrowWhenAthleteDoesNotExist()
        {
            Gym gym = new Gym("Respect", 15);
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Nikola Sirmov"));
        }

        [Test]
        public void InjureAthleteShouldReturnSameAthlete()
        {
            Gym gym = new Gym("Respect", 15);
            Athlete athlete = new Athlete("Nikola Sirmov");
            gym.AddAthlete(athlete);
            Assert.AreSame(athlete, gym.InjureAthlete("Nikola Sirmov"));
        }

        [Test]
        public void ReportShouldWorkCorrectly()
        {
            Gym gym = new Gym("Respect", 15);
            Athlete athlete1 = new Athlete("Nikola Sirmov");
            Athlete athlete2 = new Athlete("Nedelcho Todorov");
            Athlete athlete3 = new Athlete("Swetoslav Stanchev");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.InjureAthlete("Swetoslav Stanchev");
            Assert.AreEqual($"Active athletes at Respect: Nikola Sirmov, Nedelcho Todorov", gym.Report());
        }
    }
}