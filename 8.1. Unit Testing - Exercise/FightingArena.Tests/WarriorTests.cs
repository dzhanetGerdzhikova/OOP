using NUnit.Framework;

namespace Tests
{
   using FightingArena;
    public class WarriorTests
    {
        Warrior firstWarrior;
        string nameFW;
        int damageFW;
        int hpFW;

        [SetUp]
        public void Setup()
        {
            nameFW = "Gosho";
            damageFW = 50;
            hpFW = 100;

        }

        [Test]
        public void InitializationWarriorAndCorrectlyProps()
        {
            firstWarrior = new Warrior(nameFW, damageFW, hpFW);
            Assert.That(firstWarrior.Name, Is.EqualTo(nameFW));
            Assert.That(firstWarrior.Damage, Is.EqualTo(damageFW));
            Assert.That(firstWarrior.HP, Is.EqualTo(hpFW));
        }
        [Test]
        public void InitializationWarriorWithNullNameThrowException()
        {
            string name = null;
            Assert.That(()=> firstWarrior = new Warrior(name, damageFW, hpFW),Throws.ArgumentException);
        }
        [Test]
        public void InitializationWarriorWithZeroDamageThrowException()
        {
            int damage = 0;
            Assert.That(() => firstWarrior = new Warrior(nameFW, damage, hpFW), Throws.ArgumentException);
        }
        [Test]
        public void InitializationWarriorWithNegativeDamageThrowException()
        {
            int damage = -10;
            Assert.That(() => firstWarrior = new Warrior(nameFW, damage, hpFW), Throws.ArgumentException);
        }
        [Test]
        public void InitializationWarriorWithNegativeHPThrowException()
        {
            int hp = -10;
            Assert.That(() => firstWarrior = new Warrior(nameFW, damageFW, hp), Throws.ArgumentException);
        }
        [Test]
        public void WarriorAttackedAnotherWarriorWittHPLowThanMinHPThrowException()
        {
            firstWarrior = new Warrior(nameFW, damageFW, hpFW);
            Warrior secondWarrior = new Warrior("Ivan", 40, 10);
            Assert.That(()=>firstWarrior.Attack(secondWarrior) , Throws.InvalidOperationException);
        }
        [Test]
        public void WarriorAttackedAnotherWarriorWithHPLowThanMinHPThrowException()
        {
            hpFW = 10;
            firstWarrior = new Warrior(nameFW, damageFW, hpFW);
            Warrior secondWarrior = new Warrior("Ivan", 40, 100);
            Assert.That(() => firstWarrior.Attack(secondWarrior), Throws.InvalidOperationException);
        }
        [Test]
        public void WarriorAttackedAnotherWarriorAndHpPointsDecrease()
        {
            firstWarrior = new Warrior(nameFW, damageFW, hpFW);
            int damageWS = 40;
            Warrior secondWarrior = new Warrior("Ivan", damageWS, 100);
            int expectedResult = firstWarrior.HP - damageWS;
            firstWarrior.Attack(secondWarrior);
            Assert.That(firstWarrior.HP, Is.EqualTo(expectedResult));
        }
        [Test]
        public void WarriorAttackedAnotherWarriorWithHpPointsLowetThanAnotherWarriorDamageThrowException()
        {
            firstWarrior = new Warrior(nameFW, damageFW, hpFW);
            int damageWS = 140;
            Warrior secondWarrior = new Warrior("Ivan", damageWS, 100);

            Assert.That(()=>firstWarrior.Attack(secondWarrior), Throws.InvalidOperationException);
        }
        [Test]
        public void WarriorAttackedAnotherWarriorWithDamageMoreThanAnotherWarrioHpAndHpWasZero()
        {
            firstWarrior = new Warrior(nameFW, damageFW, hpFW);
            int damageWS = 40;
            int hpWS = 40;
            Warrior secondWarrior = new Warrior("Ivan", damageWS, hpWS);
            firstWarrior.Attack(secondWarrior);
            Assert.That(secondWarrior.HP, Is.EqualTo(0));
        }
        [Test]
        public void WarriorAttackedAnotherWarriorWithDamageAndDecreaseHisHp()
        {
            damageFW = 20;
            firstWarrior = new Warrior(nameFW, damageFW, hpFW);
            int damageWS = 40;
            int hpWS = 60;
            int expectedResult = hpWS - damageFW;
            Warrior secondWarrior = new Warrior("Ivan", damageWS, hpWS);
            firstWarrior.Attack(secondWarrior);
            Assert.That(secondWarrior.HP, Is.EqualTo(expectedResult));
        }
    }
}