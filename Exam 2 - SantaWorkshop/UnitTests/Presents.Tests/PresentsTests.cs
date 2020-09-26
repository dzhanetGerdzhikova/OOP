namespace Presents.Tests

{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private string presentType = "Ball";
        private double magicLevel = 5;
        private Bag bag;

        [SetUp]
        public void InitiallSetup()
        {
            present = new Present(presentType, magicLevel);
            bag = new Bag();
        }

        [Test]
        public void IsCorrectNameSetOfPresent()
        {
            Assert.That(present.Name, Is.EqualTo(presentType));
        }

        [Test]
        public void IntilializingPresentMatchCorrectMagic()
        {
            Assert.That(present.Magic, Is.EqualTo(magicLevel));
        }

        [Test]
        public void CreatingBagReturnsEmptyCollectionInGetPresents()
        {
            Assert.That(bag.GetPresents().Count, Is.EqualTo(0));
        }

        [Test]
        public void CreatingNullPresentThrowsException()
        {
            present = null;
            Assert.That(() => bag.Create(present), Throws.ArgumentNullException);
        }

        [Test]
        public void CreatePresentThatAllreadyExistsThrowException()
        {
            bag.Create(present);
            Assert.That(() => bag.Create(present), Throws.InvalidOperationException);
        }

        [Test]
        public void CreatePresentSucessfully()
        {
            Assert.That(bag.Create(present), Is.EqualTo($"Successfully added present {presentType}."));
            Assert.That(bag.GetPresents().Count, Is.EqualTo(1));
            Assert.That(bag.GetPresents().First(), Is.EqualTo(present));
        }

        [Test]
        public void RemovePresentSucessfully()
        {
            bag.Create(present);
            Assert.That(bag.Remove(present), Is.True);
            Assert.That(bag.GetPresents().Count, Is.EqualTo(0));
        }

        [Test]
        public void RemovePresentThatDoesNotExist()
        {
            Assert.IsFalse(bag.Remove(present));
        }

        [Test]
        public void IsPresentExsistsWihtTheSameName()
        {
            bag.Create(present);
            Assert.That(bag.GetPresent(presentType), Is.EqualTo(present));
        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            bag.Create(present);
            Present secondPresent = new Present("Table", 15);
            bag.Create(secondPresent);

            Assert.That(bag.GetPresentWithLeastMagic(), Is.EqualTo(present));
        }
    }
}