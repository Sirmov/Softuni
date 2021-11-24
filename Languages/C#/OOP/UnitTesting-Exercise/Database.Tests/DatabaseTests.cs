using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        [TestCase(-1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -16)]
        [TestCase(-1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -16)]
        [TestCase(int.MaxValue, int.MinValue, 0)]
        public void ConstructorShouldWorkWithIntegers(params int[] elements)
        {
            Database database = new Database(elements);
            Assert.AreEqual(elements.Length, database.Count);
            CollectionAssert.AreEqual(elements, database.Fetch());
        }

        [Test]
        public void ConstructorShouldThrowWhenElementsAreOver16()
        {
            int[] elements = new int[17];
            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(16)]
        public void AddShouldWorkWithIntegers(int lenght)
        {
            Database database = new Database();
            int[] elements = Enumerable.Range(0, lenght).ToArray();

            for (int i = 0; i < lenght; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(elements.Length, database.Count);
            CollectionAssert.AreEqual(elements, database.Fetch());
        }

        [Test]
        public void AddShouldThrowExceptionWhenDatabaseIsFull()
        {
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(16)]
        public void RemoveShouldWorkWithIntegers(int count)
        {
            Database database = new Database(Enumerable.Range(0, 16).ToArray());

            for (int i = 0; i < count; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(16 - count, database.Count);
            CollectionAssert.AreEqual(Enumerable.Range(0, 16 - count).ToArray(), database.Fetch());
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4, 5)]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty(params int[] data)
        {
            Database database = new Database(data);

            for (int i = 0; i < data.Length; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(database.Remove);
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        [TestCase(-5, -6, -7, -8, -9, -10)]
        public void FetchShouldReturnElementsAsArray(params int[] elements)
        {
            Database database = new Database(elements);

            Assert.AreEqual(elements.Length, database.Count);
            CollectionAssert.AreEqual(elements, database.Fetch());
        }
    }
}