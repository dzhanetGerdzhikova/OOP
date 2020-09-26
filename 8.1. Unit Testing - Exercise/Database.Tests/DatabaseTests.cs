using NUnit.Framework;
using System.Linq;

namespace Tests
{
    using Database;

    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StoringArrayCapacityMustBeExactly16Integers()
        {
            int[] array = new int[16];
            Database data = new Database(array);
            Assert.That(data.Count, Is.EqualTo(array.Count()));
        }
        [Test]
        public void StoringArrayCapacityThrowExceptionWhenCapacityIsOver16()
        {
            int[] array = new int[17];
            Database data;
            Assert.That(() => data = new Database(array), Throws.InvalidOperationException);
        }
        [Test]
        public void CorrectlyAddElementInDataWhenHaveAFreePlace()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database data = new Database(array);
            data.Add(8);
            Assert.That(data.Count, Is.EqualTo(array.Count() + 1));
        }
        [Test]
        public void ThrowExceptionWhenDataAddElementAndDidntHaveFreePlace()
        {
            int[] array = new int[16];
            Database data = new Database(array);
            Assert.That(() => data.Add(5), Throws.InvalidOperationException);
        }
        [Test]
        public void CorrectlyRemoveElementFromData()
        {
            int[] array = new int[16];
            Database data = new Database(array);
            data.Remove();
            Assert.That(data.Count, Is.EqualTo(array.Count() - 1));
        }
        [Test]
        public void RemoveElementFromEmptyDataThrowException()
        {
            int[] array = new int[0];
            Database data = new Database(array);
            Assert.That(() => data.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void FetchReturnSameElementsFromDataInArray()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database data = new Database(array);
          int[] coppyArray =  data.Fetch();

            CollectionAssert.AreEqual(coppyArray, array);
        }
    }
}