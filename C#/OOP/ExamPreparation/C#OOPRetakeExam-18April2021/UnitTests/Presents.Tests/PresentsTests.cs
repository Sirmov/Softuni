namespace Presents.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            Bag bag = new Bag();
            Assert.IsNotNull(bag.GetPresents());
        }

        [Test]
        public void CreatePresentShouldNotAcceptNull()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void CreatePresentShouldNotAcceptDuplicats()
        {
            Bag bag = new Bag();
            Present present = new Present("Ball", 30);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        //[Test]
        //public void CreatePresentShouldCreatePresent()
        //{
        //    Bag bag = new Bag();
        //    Present present = new Present("Ball", 30);
        //    bag.Create(present);
        //    Assert.AreEqual(1, bag.GetPresents().Count);
        //}

        [Test]
        public void RemoveShouldRemoveElement()
        {
            Bag bag = new Bag();
            Present present = new Present("Ball", 30);
            bag.Create(present);
            bag.Remove(present);
            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void GetPresentWithLeasMagicShouldWorkCorrectly()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Ball1", 30);
            Present present2 = new Present("Ball2", 100);
            bag.Create(present1);
            bag.Create(present2);
            Assert.AreSame(present1, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresentShouldReturnPresent()
        {
            Bag bag = new Bag();
            Present present = new Present("Ball", 30);
            bag.Create(present);
            Assert.AreSame(present, bag.GetPresent("Ball"));
        }
    }
}