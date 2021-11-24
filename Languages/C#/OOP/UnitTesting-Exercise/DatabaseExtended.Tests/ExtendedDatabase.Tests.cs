using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Person[] people = new Person[]
            {
                new Person(123, "Nikola"),
                new Person(321, "Sirmov")
            };

            ExtendedDatabase database = new ExtendedDatabase(people);

            Assert.AreEqual(people.Length, database.Count);
        }

        [Test]
        public void ConstructorShouldNotAcceptElementsOver16()
        {
            Person[] people = new Person[17];
            StringBuilder name = new StringBuilder("Test");
            for (int i = 0; i < 17; i++)
            {
                name.Append(i.ToString());
                people[i] = new Person(i, name.ToString());
            }
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people),
                "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddShouldWorkCorrectly()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            database.Add(new Person(123, "Nikola"));

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenElementsAreOver16()
        {
            Person[] people = new Person[16];
            StringBuilder name = new StringBuilder("Test");
            for (int i = 0; i < 16; i++)
            {
                name.Append(i.ToString());
                people[i] = new Person(i, name.ToString());
            }
            ExtendedDatabase database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(123, "Nikola")),
                "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenUsernameExists()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            database.Add(new Person(123, "Nikola"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(124, "Nikola")),
                "There is already user with this username!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenIdExists()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            database.Add(new Person(123, "Nikola"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(123, "Sirmov")),
                "There is already user with this Id!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void RemoveShouldWorkCorrectly(int count)
        {
            Person[] people = new Person[]
            {
                new Person(123, "Nikola"),
                new Person(124, "Sirmov"),
                new Person(125, "Stoyan")
            };
            ExtendedDatabase database = new ExtendedDatabase(people);

            for (int i = 0; i < count; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(people.Length - count, database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase("Nikola")]
        [TestCase("Sirmov")]
        [TestCase("Stoyan")]
        public void FindByUserNameShouldWorkCorrectly(string username)
        {
            Person[] people = new Person[]
            {
                new Person(123, "Nikola"),
                new Person(124, "Sirmov"),
                new Person(125, "Stoyan")
            };
            ExtendedDatabase database = new ExtendedDatabase(people);
            Person actual = database.FindByUsername(username);
            Person expected = people.FirstOrDefault(p => p.UserName == username);

            Assert.AreEqual(expected.UserName, actual.UserName);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameShouldNotAcceptNullOrEmpty(string username)
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username),
                "Username parameter is null!");
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenUserDoesNotExist()
        {
            Person[] people = new Person[]
            {
                new Person(123, "Nikola"),
                new Person(124, "Sirmov"),
                new Person(125, "Stoyan")
            };
            ExtendedDatabase database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Pesho"),
                "No user is present by this username!");
        }

        [TestCase(123)]
        [TestCase(124)]
        [TestCase(125)]
        public void FindByIdShouldWorkCorrectly(long id)
        {
            Person[] people = new Person[]
            {
                new Person(123, "Nikola"),
                new Person(124, "Sirmov"),
                new Person(125, "Stoyan")
            };
            ExtendedDatabase database = new ExtendedDatabase(people);
            Person actual = database.FindById(id);
            Person expected = people.FirstOrDefault(p => p.Id == id);

            Assert.AreEqual(expected.UserName, actual.UserName);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(long.MinValue)]
        public void FindByIdShouldNotAcceptNegativeNumbers(long id)
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id),
                "Id should be a positive number!");
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenUserDoesNotExist()
        {
            Person[] people = new Person[]
            {
                new Person(123, "Nikola"),
                new Person(124, "Sirmov"),
                new Person(125, "Stoyan")
            };
            ExtendedDatabase database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => database.FindById(321),
                "No user is present by this ID!");
        }
    }
}