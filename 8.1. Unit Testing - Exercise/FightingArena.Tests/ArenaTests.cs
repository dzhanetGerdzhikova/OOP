using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    public class ArenaTests
    {
        Warrior firstWar;
        string firstNameWar;
        int firstDamageWar;
        int firstHpWar;
        Warrior secondWar;
        string secondNameWar;
        int secondDamageWar;
        int secondHpWar;
        [SetUp]
        public void Setup()
        {
            firstNameWar = "Gosho";
            firstDamageWar = 30;
            firstHpWar = 40;
            secondNameWar = "Ivan";
            secondDamageWar = 40;
            secondHpWar = 50;
        }

        [Test]
        public void InitializationCorrectlyArena()
        {
            Arena arena = new Arena();
            Assert.That(() => arena.Count, Is.EqualTo(0));
        }
        [Test]
        public void DecreaseCounAreneWhenAddedWarrior()
        {
            firstWar = new Warrior(firstNameWar, firstDamageWar, firstHpWar);
            Arena arena = new Arena();
            arena.Enroll(firstWar);
            Assert.That(firstWar.Name, Is.EqualTo(firstNameWar));
        }
        [Test]
        public void AddedExistingWarriorThrowExeption()
        {
            firstWar = new Warrior(firstNameWar, firstDamageWar, firstHpWar);
            secondWar = new Warrior(firstNameWar, secondDamageWar, secondHpWar);
            Arena arena = new Arena();
            arena.Enroll(firstWar);
            Assert.That(()=>arena.Enroll(secondWar),Throws.InvalidOperationException);
        }
        [Test]
        public void ArenaFightWithAttackerWithNullNameThrowExeption()
        {
            firstWar = new Warrior(firstNameWar, firstDamageWar, firstHpWar);
            secondWar = new Warrior(secondNameWar, secondDamageWar, secondHpWar);
            Arena arena = new Arena();
            arena.Enroll(firstWar);
            arena.Enroll(secondWar);
            Assert.That(() => arena.Fight(null, secondNameWar),Throws.InvalidOperationException);
        }
        [Test]
        public void ArenaFightWithDefenderWithNullNameThrowExeption()
        {
            firstWar = new Warrior(firstNameWar, firstDamageWar, firstHpWar);
            secondWar = new Warrior(secondNameWar, secondDamageWar, secondHpWar);
            Arena arena = new Arena();
            arena.Enroll(firstWar);
            arena.Enroll(secondWar);
            Assert.That(() => arena.Fight(firstNameWar, null), Throws.InvalidOperationException);
        }
        [Test]
        public void ArenaFightWithAttackerIncreaseHp()
        {
            firstWar = new Warrior(firstNameWar, firstDamageWar, firstHpWar);
            secondWar = new Warrior(secondNameWar, secondDamageWar, secondHpWar);
            Arena arena = new Arena();
            arena.Enroll(firstWar);
            arena.Enroll(secondWar);
            arena.Fight(firstNameWar, secondNameWar);
            Assert.That(firstWar.HP,Is.EqualTo(firstHpWar-secondDamageWar));
        }
    }
}
