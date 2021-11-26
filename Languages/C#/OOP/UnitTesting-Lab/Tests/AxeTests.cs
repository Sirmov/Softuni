using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    internal class AxeTests
    {
        private Axe axe;
        private Axe brokenAxe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            this.axe = new Axe(10, 45);
            this.brokenAxe = new Axe(10, 0);
            this.dummy = new Dummy(10, 100);
        }

        [Test]
        public void AxeShouldLoseDurability()
        {
            this.axe.Attack(this.dummy);
            Assert.Less(this.axe.DurabilityPoints, 45, "Axe doesn't lose durability!");
            Assert.AreEqual(44, this.axe.DurabilityPoints, "Axe should lose 1 durability per attack!");
        }

        [Test]
        public void BrokenAxeShouldNotBeAbleToAttack()
        {
            Assert.Throws<InvalidOperationException>(() => this.brokenAxe.Attack(this.dummy));
        }
    }
}
