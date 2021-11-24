using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        [TestCase("Nikola", 1, 100)]
        [TestCase("Sirmov", 50, 0)]
        [TestCase("Stoyan", 50, 100)]
        [TestCase("Pe Sho", 50, 100)]
        public void ConstructorShouldWorkCorrectly(string name, int damage, int health)
        {
            Warrior warrior = new Warrior(name, damage, health);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(health, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameCannotBeNullEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 50, 100),
                "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void DamageShouldBePositive(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Nikola", damage, 100),
                "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(int.MinValue)]
        public void HealthShouldNotBeNegative(int health)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Nikola", 50, health),
                "HP should not be negative!");
        }

        [TestCase(50, 100, 50, 1)]
        [TestCase(50, 100, 50, 50)]
        [TestCase(50, 50, 50, 50)]
        [TestCase(50, 50, 100, 50)]
        [TestCase(100, 50, 50, 50)]
        public void AttackShouldWorkCorrectly(int attackerHP, int attackerDMG, int defenderHP, int defenderDMG)
        {
            Warrior attacker = new Warrior("Nikola", attackerDMG, attackerHP);
            Warrior defender = new Warrior("Sirmov", defenderDMG, defenderHP);

            attacker.Attack(defender);

            int expected = attackerDMG > defenderHP ? 0 : defenderHP - attackerDMG;
            Assert.AreEqual(attackerHP - defenderDMG, attacker.HP);
            Assert.AreEqual(expected, defender.HP);
        }

        [TestCase(30)] // Check borders
        [TestCase(29)]
        [TestCase(0)]
        public void AttackShouldThrowExceptionWhenAttackerHealthIsTooLow(int health)
        {
            Warrior attacker = new Warrior("Nikola", 50, health);
            Warrior defender = new Warrior("Sirmov", 50, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender),
                "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)] // Check borders
        [TestCase(29)]
        [TestCase(0)]
        public void AttackShouldThrowExceptionWhenDefenderHealthIsTooLow(int health)
        {
            Warrior attacker = new Warrior("Nikola", 50, 100);
            Warrior defender = new Warrior("Sirmov", 50, health);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender),
                $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [TestCase(50, 60)]
        [TestCase(0, 1)]
        [TestCase(50, 51)]
        public void AttackShouldThrowExceptionWhenAttackerHealthIsLowerThanDefenderDamage(int attackerHP, int defenderDamage)
        {
            Warrior attacker = new Warrior("Nikola", 50, attackerHP);
            Warrior defender = new Warrior("Sirmov", defenderDamage, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender),
                "You are trying to attack too strong enemy");
        }
    }
}