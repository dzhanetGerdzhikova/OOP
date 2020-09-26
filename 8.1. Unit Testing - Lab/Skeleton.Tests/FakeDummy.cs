namespace Skeleton.Tests
{
    public class FakeDummy : ITarget
    {
        private bool isDead = false;

        public FakeDummy(bool isDead)
        {
            this.isDead = isDead;
        }

        public int Health => 15;

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeAttack(int attackPoints)
        {
        }
    }
}