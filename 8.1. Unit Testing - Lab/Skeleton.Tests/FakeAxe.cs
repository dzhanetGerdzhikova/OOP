namespace Skeleton.Tests
{
    public class FakeAxe : IWeapon
    {
        public int AttackPoints => 10;

        public int DurabilityPoints => 10;

        public void Attack(ITarget target)
        {
            //target.TakeAttack(AttackPoints);
        }
    }
}