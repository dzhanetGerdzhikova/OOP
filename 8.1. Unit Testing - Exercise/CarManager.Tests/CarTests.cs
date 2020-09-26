using NUnit.Framework;

namespace Tests
{
    using CarManager;
    public class CarTests
    {
        Car car;
        string make = "Audi";
        string model = "A8";
        double fuelConsumption = 10;
        double fuelCapacity = 100;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CorrectlyInitializationCarWithRightProps()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }
        [Test]
        public void InitializationCarWithZeroAmount()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }
        [Test]
        public void InitializationCarWithNullMakeThrowException()
        {
            string make = null;
            Assert.That(() => car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        }
        [Test]
        public void InitializationCarWithNullModelThrowException()
        {
            string model = null;
            Assert.That(() => car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        }
        [Test]
        public void InitializationCarWithNegativeConsumptionThrowException()
        {
            double fuelConsumption = -10;
            Assert.That(() => car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        }
        [Test]
        public void InitializationCarWithZeroConsumptionThrowException()
        {
            double fuelConsumption = 0;
            Assert.That(() => car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        }
        [Test]
        public void InitializationCarWithNegativeCapacityThrowException()
        {
            double fuelCapacity = -100;
            Assert.That(() => car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        }
        [Test]
        public void InitializationCarWithZeroCapacityThrowException()
        {
            double fuelCapacity = 0;
            Assert.That(() => car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        }
        [Test]
        public void CarRefuleWithNegativeValue()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(() => car.Refuel(-10), Throws.ArgumentException);
        }
        [Test]
        public void CarRefuleWithNeroValue()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(() => car.Refuel(0), Throws.ArgumentException);
        }
        [Test]
        public void CarRefuleWithValue()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            double refulingValue = 10;
            car.Refuel(refulingValue);
            Assert.That(car.FuelAmount, Is.EqualTo(refulingValue));

        }
        [Test]
        public void CarRefuleWithValueMoreThanCapacity()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            double refulingValue = 110;
            car.Refuel(refulingValue);
            Assert.That(car.FuelAmount, Is.EqualTo(fuelCapacity));
        }
        [Test]
        public void CarDriveWithNormalDistance()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(80);
            car.Drive(20);
            double neededFuel = 2;
            Assert.That(car.FuelAmount, Is.EqualTo(80 - neededFuel));
        }
        [Test]
        public void CarDriveWithDistanceMoreThanAmount()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.That(()=>car.Drive(20),Throws.InvalidOperationException);
        }
    }
}