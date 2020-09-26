using CounterStrike.Models.Guns.Contracts;
using System;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun, IGun
    {
        private const int strikeBullet = 10;

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (BulletsCount - strikeBullet < 0)
            {
                return 0;
            }
            BulletsCount -= strikeBullet;
            return strikeBullet;
        }
    }
}