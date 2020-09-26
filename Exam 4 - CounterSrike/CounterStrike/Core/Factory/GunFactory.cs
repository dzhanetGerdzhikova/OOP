using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Core.Factory
{
    public static class GunFactory
    {
        public static IGun CreateGun(string type, string name, int bullestCount)
        {
            if (type == nameof(Pistol))
            {
                return new Pistol(name, bullestCount);
            }
            else if(type==nameof(Rifle))
            {
                return new Rifle(name, bullestCount);
            }
            return null;
        }
    }
}