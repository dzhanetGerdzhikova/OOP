namespace Aquariums.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;
        private int aquariumCapacity = 10;
        private int negativeAquariumCapacity = -10;
        private string fishName = "Gosho";
        private string aquariumName = "Ezero";

        [SetUp]
        public void InitialSetup()
        {
            fish = new Fish(fishName);
            aquarium = new Aquarium(aquariumName, aquariumCapacity);
        }

        [Test]
        public void IsFishInitiallyAvailable()
        {
            Assert.That(fish.Available, Is.True);
        }

        [Test]
        public void IsNameInitiallySetCorrectly()
        {
            Assert.That(fish.Name, Is.EqualTo(fishName));
        }

        [Test]
        public void SettingEmptyAquariumNameThrowsException()
        {
            Assert.That(() => new Aquarium("", aquariumCapacity), Throws.ArgumentNullException.And.Message.EqualTo("Invalid aquarium name! (Parameter 'value')"));
        }

        [Test]
        public void SettingNullAquariumNameThrowsException()
        {
            Assert.That(() => new Aquarium(null, aquariumCapacity), Throws.ArgumentNullException.And.Message.EqualTo("Invalid aquarium name! (Parameter 'value')"));
        }

        [Test]
        public void SettingWhitespaceAquariumNameDoesNotThrowsException()
        {
            Assert.That(() => new Aquarium(" ", aquariumCapacity), Throws.Nothing);
        }

        [Test]
        public void SettingNegativeAquariumCapacityThrowsException()
        {
            Assert.That(() => new Aquarium(aquariumName, negativeAquariumCapacity), Throws.ArgumentException.And.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        public void SettingZeroAquariumCapacityDoesNotThrowsException()
        {
            Assert.That(() => new Aquarium(aquariumName, 0), Throws.Nothing);
        }

        [Test]
        public void VerifyInitialCountOfFishIsZero()
        {
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void VerifyCountIcreasesWhenFishIsAdded()
        {
            aquarium.Add(fish);
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void ReachingMaxCapacityWhenAddingFishThrowsException()
        {
            for (int i = 0; i < aquariumCapacity; i++)
            {
                aquarium.Add(fish);
            }

            Assert.That(() => aquarium.Add(fish), Throws.InvalidOperationException.And.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        public void RemoveFishDescreaseFishCount()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish(fish.Name);
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveFishThatDoesNotExistThrowsException()
        {
            Assert.That(() => aquarium.RemoveFish(fishName), Throws.InvalidOperationException);
        }

        [Test]
        public void SuccessfullySellFish()
        {
            aquarium.Add(fish);
            var selledFish = aquarium.SellFish(fish.Name);

            Assert.That(selledFish.Available, Is.False);
        }


        [Test]
        public void SellingFishThatDoesNotExistThrowsException()
        {
            Assert.That(() => aquarium.SellFish(fishName), Throws.InvalidOperationException);
        }
        [Test]
        public void ReportMessages()
        {
            Fish secondFish = new Fish("Ivan");
            aquarium.Add(fish);
            aquarium.Add(secondFish);
            Assert.That(aquarium.Report(), Is.EqualTo($"Fish available at {aquarium.Name}: {fish.Name}, {secondFish.Name}"));
        }
    }
}