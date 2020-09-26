using NUnit.Framework;
using Skeleton.Tests;

[TestFixture]
public class DummyTests : BaseTest
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Assert.That(dummy.Health, Is.EqualTo(axeAttack), "Dummy didn't lose correctly health after attacked.");
    }

    [Test]
    public void AttackingDeadDummyThrowsException()
    {
        axe.Attack(dummy);
        Assert.That(() => dummy.TakeAttack(dummyHealth), Throws.InvalidOperationException.And.Message.EqualTo("Dummy is dead."), "Attacking dead dummy doesn't throw exception");
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        axe.Attack(dummy);
        Assert.That(dummy.GiveExperience(), Is.EqualTo(dummyExperience), "Dead dummy didn't give XP.");
    }

    [Test]
    public void AliveDummyThrowsExceptionWhenGiveXP()
    {
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.And.Message.EqualTo("Target is not dead."), "Alive dummy didn't throw exception when give XP.");
    }
}