using NUnit.Framework;

namespace Skeleton.Tests
{
    public class BaseTest
    {
        protected IWeapon axe;
        protected ITarget dummy;
        protected Hero hero;

        protected const int dummyExperience = 20;
        protected const int dummyHealth = 10;
        protected const int axeAttack = 5;
        protected const int axeDurability = 10;

        [SetUp]
        public void Initialization()
        {
            axe = new Axe(axeAttack, axeDurability);
            dummy = new Dummy(dummyHealth, dummyExperience);
            hero = new Hero("Gosho", axe);
            axe.Attack(dummy);
        }
    }
}