using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        Person ivan;
        Person anna;
        ExtendedDatabase data;
        [SetUp]
        public void Setup()
        {
            ivan = new Person(5165, "Ivan");
            anna = new Person(5651, "Anna");
            data = new ExtendedDatabase(ivan, anna);

        }

        [Test]
        public void AddAllreadyExistUserWithTheSameIDThrowException()
        {
            Person katq = new Person(5165, "Katq");

            Assert.That(() => data.Add(katq), Throws.InvalidOperationException);
        }
        [Test]
        public void AddAllreadyExistUserWithTheSameNameThrowException()
        {
            Person anna = new Person(55485, "Anna");

            Assert.That(() => data.Add(anna), Throws.InvalidOperationException);
        }
        [Test]
        public void AddPeopleInFullDataThrowException()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = (new Person(i, $"Abc+{i}"));
            }
            data = new ExtendedDatabase(people);
            Person sasho = new Person(153165, "Sasho");
            Assert.That(() => data.Add(sasho), Throws.InvalidOperationException);
        }
        [Test]
        public void CorrectlyRemoveElementFromData()
        {
            data.Remove();
            int expectedValue = 1;
            Assert.That(data.Count, Is.EqualTo(expectedValue));
        }
        [Test]
        public void RemoveFromEmptyDataThrowException()
        {
            data.Remove();
            data.Remove();
            Assert.That(() => data.Remove(), Throws.InvalidOperationException);

        }
        [Test]
        public void FindPeopleWithNameDidntExistThrowException()
        {
            Assert.That(() => data.FindByUsername("Gosho"), Throws.InvalidOperationException);
        }
        [Test]
        public void FindPeopleWithLowerCaseNameThrowException()
        {
            Assert.That(() => data.FindByUsername("anna"), Throws.InvalidOperationException);
        }
        [Test]
        public void FindPeopleWithUpperCaseNameThrowException()
        {
            Assert.That(() => data.FindByUsername("ANNA"), Throws.InvalidOperationException);
        }
        [Test]
        public void FindPeopleWithSameName()
        {
            Assert.That(data.FindByUsername("Anna"), Is.EqualTo(anna));
        }
        [Test]
        public void FindPeopleWithNameNullThrowException()
        {
            Assert.That(() => data.FindByUsername(null), Throws.ArgumentNullException);
        }
        [Test]
        public void FindPeopleWithIdDidntExistThrowException()
        {
            Assert.That(() => data.FindById(6516358), Throws.InvalidOperationException);
        }
        [Test]
        public void FindPeopleWithNegativeIdThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => data.FindById(-6516358));
        }
        [Test]
        public void FindPeopleWithSameId()
        {
            Assert.That(data.FindById(5651), Is.EqualTo(anna));
        }
    }
}