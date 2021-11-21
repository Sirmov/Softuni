using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Test", "Test", 5, 50);
        }

        [TestCase("Honda", "Civic", 7.8, 45.5)]
        [TestCase("BMW", "E60", 8.9, 65)]
        [TestCase("Opel", "Astra", 6.5, 40)]
        public void CarConstructorShouldReturnCar(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null, "A7", 8, 80)]
        [TestCase("", "A7", 8, 80)]
        [TestCase("Audi", null, 8, 80)]
        [TestCase("Audi", "", 8, 80)]
        [TestCase("Audi", "A7", 5, 0)]
        [TestCase("Audi", "A7", 5, -1)]
        [TestCase("Audi", "A7", 0, 5)]
        [TestCase("Audi", "A7", -1, 5)]
        public void CarConstructorShouldNotAcceptInvalidArguments(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarRefuelShoulWorkCorrectly()
        {
            this.car.Refuel(24.5);
            Assert.AreEqual(24.5, this.car.FuelAmount);
            this.car.Refuel(24.5);
            Assert.AreEqual(49, this.car.FuelAmount);
        }

        [Test]
        public void CarRefuelShouldNotAcceptNonPositiveValues()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
            Assert.Throws<ArgumentException>(() => this.car.Refuel(-1));
        }

        [Test]
        public void CarRefuelShouldNotOverflow()
        {
            this.car.Refuel(51);
            Assert.AreEqual(50, this.car.FuelAmount);
        }

        [Test]
        public void CarDriveShouldWorkCorrectly()
        {
            this.car.Refuel(50);
            this.car.Drive(100);
            Assert.AreEqual(45, this.car.FuelAmount);
            this.car.Drive(50.5);
            Assert.AreEqual(42.475, this.car.FuelAmount);
        }

        [Test]
        public void CarDriveShouldThrowWhenFuelTankIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1));
        }

        [Test]
        public void CarDriveShouldThrowWhenNotEnoughFuel()
        {
            this.car.Refuel(10);
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(205));
        }

        //[Test]
        //public void CarDriveShouldNotAcceptNegativeDistance()
        //{
        //    this.car.Refuel(50);
        //    Assert.Throws<Exception>(() => this.car.Drive(-1));
        //}
    }
}