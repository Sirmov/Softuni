using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    internal class DummyTests
    {
        private Dummy aliveDummy;
        private Dummy deadDummy;

        [SetUp]
        public void SetUp()
        {
            this.aliveDummy = new Dummy(10, 50);
            this.deadDummy = new Dummy(0, 20);
        }

        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            this.aliveDummy.TakeAttack(1);
            Assert.Less(this.aliveDummy.Health, 10);
            Assert.AreEqual(9, this.aliveDummy.Health);
        }

        [Test]
        public void DeadDummySholdThrowExceptionWhenAttacked()
        {
            Assert.Throws<InvalidOperationException>(() => this.deadDummy.TakeAttack(5));
        }

        [Test]
        public void DeadDummyShouldNotGiveExperience()
        {
            int experience = this.deadDummy.GiveExperience();
            Assert.AreEqual(20, experience);
        }

        [Test]
        public void AliveDummyShouldNotGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() => this.aliveDummy.GiveExperience());
        }
    }
}
