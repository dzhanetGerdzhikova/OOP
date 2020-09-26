using Moq;
using NUnit.Framework;
using Skeleton;
using Skeleton.Tests;

[TestFixture]
public class HeroTests : BaseTest
{
    [Test]
    public void HeroBecomeXPWhenDummyIsDead()
    {
        //FakeAxe fakeAxe = new FakeAxe();
        //FakeDummy fakeDummy = new FakeDummy(true);

        Mock<IWeapon> fakeAxe = new Mock<IWeapon>();
        Mock<ITarget> fakeDummy = new Mock<ITarget>();

        hero = new Hero("Gosho", fakeAxe.Object);
        hero.Attack(fakeDummy.Object);
        Assert.That(hero.Experience, Is.EqualTo(20));
    }

    [Test]
    public void HeroDidntBecameXPWhenDummyIsDead()
    {
        FakeAxe fakeAxe = new FakeAxe();
        FakeDummy fakeDummy = new FakeDummy(false);

        hero = new Hero("Gosho", fakeAxe);
        hero.Attack(fakeDummy);
        Assert.That(hero.Experience, Is.EqualTo(0));
    }
}