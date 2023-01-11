using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private const int MIN_ATTACK_HP = 30;
        private Arena arena;

        [SetUp]
        public void ArenaSetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitializeWarriorsList()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(0, arena.Warriors.Count);
        }

        [TestCase("Nikola", 100, 50)]
        public void EnrollShoulAddWarrior(string name, int health, int damage)
        {
            Warrior warrior = new Warrior(name, damage, health);
            this.arena.Enroll(warrior);

            Assert.AreEqual(1, this.arena.Warriors.Count);
            Assert.True(this.arena.Warriors.Any(w => w.Name == name && w.HP == health && w.Damage == damage));
        }

        [Test]
        public void EnrollShouldThrowExceptionWhenWarriorExists()
        {
            Warrior warrior = new Warrior("Nikola", 50, 100);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior),
                "Warrior is already enrolled for the fights!");
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        public void CountShouldReturnWarriorsCount(int count)
        {
            Warrior[] warriors = new Warrior[count];
            for (int i = 0; i < count; i++)
            {
                warriors[i] = new Warrior(i.ToString(), 50, 100);
            }

            foreach (var warrior in warriors)
            {
                this.arena.Enroll(warrior);
            }

            Assert.AreEqual(count, this.arena.Count);
        }

        [TestCase("Nikola", "Pesho")]
        [TestCase("Pesho", "Nikola")]
        [TestCase("Pesho", "Pesho")]
        public void FightShouldThrowExceptionWhenWarriorIsMissing(string attackerName, string defenderName)
        {
            this.arena.Enroll(new Warrior("Nikola", 50, 100));
            this.arena.Enroll(new Warrior("Sirmov", 50, 100));
            this.arena.Enroll(new Warrior("Stoyan", 50, 100));

            Warrior attacker = this.arena.Warriors
                .FirstOrDefault(w => w.Name == attackerName);
            Warrior defender = this.arena.Warriors
                .FirstOrDefault(w => w.Name == defenderName);

            string missingName = null;

            if (attacker == null || defender == null)
            {
                missingName = attackerName;

                if (defender == null)
                {
                    missingName = defenderName;
                }
            }

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attackerName, defenderName),
            $"There is no fighter with name {missingName} enrolled for the fights!");
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
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight("Nikola", "Sirmov");

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

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Nikola", "Sirmov"),
                "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)] // Check borders
        [TestCase(29)]
        [TestCase(0)]
        public void AttackShouldThrowExceptionWhenDefenderHealthIsTooLow(int health)
        {
            Warrior attacker = new Warrior("Nikola", 50, 100);
            Warrior defender = new Warrior("Sirmov", 50, health);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Nikola", "Sirmov"),
                $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [TestCase(50, 60)]
        [TestCase(0, 1)]
        [TestCase(50, 51)]
        public void AttackShouldThrowExceptionWhenAttackerHealthIsLowerThanDefenderDamage(int attackerHP, int defenderDamage)
        {
            Warrior attacker = new Warrior("Nikola", 50, attackerHP);
            Warrior defender = new Warrior("Sirmov", defenderDamage, 100);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Nikola", "Sirmov"),
                "You are trying to attack too strong enemy");
        }
    }
}