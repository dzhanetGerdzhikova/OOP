using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        private const int strikeBullet = 1;
        public Pistol(string name, int bulletsCount)
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
