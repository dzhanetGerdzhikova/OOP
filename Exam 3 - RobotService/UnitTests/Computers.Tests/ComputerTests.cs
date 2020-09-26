namespace Computers.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ComputerTests
    {
        private string partName = "First";
        private decimal partPrice = 10;
        private Part part;
        private string computerName = "Lenovo";
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            part = new Part(partName, partPrice);
            computer = new Computer(computerName);
        }

        [Test]
        public void CorrectlySetUpByNamePartInCtro()
        {
            Assert.That(part.Name, Is.EqualTo(partName));
        }
        [Test]
        public void CorrectlySetUpByPricePartInCtro()
        {
            Assert.That(part.Price, Is.EqualTo(partPrice));
        }
        [Test]
        public void CorrectlySetUpByNameCompuretInCtro()
        {
            Assert.That(computer.Name, Is.EqualTo(computerName));
        }
        [Test]
        public void CorrectlySetUpCollectionInCompuretCtro()
        {
           
            Assert.That(computer.Parts.Count, Is.EqualTo(0));
        }
        [Test]
        public void CompNameNullThrowNewException()
        {
            Assert.That(()=> new Computer(""), Throws.ArgumentNullException.And.Message.EqualTo("Name cannot be null or empty! (Parameter 'Name')"));
           
        }
        [Test]
        public void CorrectlyPropTotalPriceSumOfOllPriceInCollection()
        {
            computer.AddPart(part);
            computer.AddPart(new Part("second", 10));
            Assert.That(computer.TotalPrice, Is.EqualTo(20));

        }
        [Test]
        public void SucssesfyllyAdded()
        {
            computer.AddPart(part);
            Assert.That(computer.Parts.Count, Is.EqualTo(1));

        }
        [Test]
        public void AddedNullPartThrowExceprion()
        {
            
            Assert.That(() => computer.AddPart(null), Throws.InvalidOperationException);

        }
        [Test]
        public void SucssesfylyRemoved()
        {
            computer.AddPart(part);
            computer.RemovePart(part);
            Assert.That(computer.Parts.Count, Is.EqualTo(0));

        }
        [Test]
        public void SucssesfulyGetPart()
        {
            computer.AddPart(part);
            Assert.That(()=>computer.GetPart(partName), Is.EqualTo(part));

        }
    }
}