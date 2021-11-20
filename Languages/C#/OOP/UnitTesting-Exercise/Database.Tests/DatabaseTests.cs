using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database();
        }

        [Test]
        public void DatabaseShouldNotAdd17thElement()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void DatabaseAddShouldAddElementsStackLike()
        {
            int[] expectedArray = new int[] { 1, 2, 3, 4, 5, 6 };
            for (int i = 1; i <= 6; i++)
            {
                this.database.Add(i);
            }

            CollectionAssert.AreEqual(expectedArray, database.Fetch());
        }

        [Test]
        public void DatabaseRemoveShouldRemoveFromLast()
        {
            int[] expectedArray = new int[] { 1, 2, 3, 4, 5 };

            for (int i = 1; i <= 10; i++)
            {
                this.database.Add(i);
            }

            for (int i = 0; i < 5; i++)
            {
                this.database.Remove();
            }

            CollectionAssert.AreEqual(expectedArray, this.database.Fetch());
        }

        [Test]
        public void DatabaseSholdRemoveShouldThrowExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void DatabaseConstructorShouldThrowExceptionWhenArrayIsBiggerThan16Elements()
        {
            int[] array = new int[17];
            Assert.Throws<InvalidOperationException>(() => new Database.Database(array));
        }

        [Test]
        public void DatabaseConstructorShouldWorkWithIntegers()
        {
            int[] expectedArray = new int[] { 0, -2500, 2500, 1, -1, 2147483647, -2147483647 };
            CollectionAssert.AreEqual(expectedArray, new Database.Database(0, -2500, 2500, 1, -1, 2147483647, -2147483647).Fetch());
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        [TestCase(new int[] {-1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -16})]
        [TestCase(new int[] { 2147483647, -2147483647 })]
        public void DatabaseFetchShouldReturnElementsAsArray(int[] expectedArray)
        {
            foreach (var num in expectedArray)
            {
                this.database.Add(num);
            }

            CollectionAssert.AreEqual(expectedArray, this.database.Fetch());
        }

        [Test]
        public void EmptyDatabaseCountShouldReturnZero()
        {
            int result = this.database.Count;
            Assert.AreEqual(0, result);
        }
    }
}