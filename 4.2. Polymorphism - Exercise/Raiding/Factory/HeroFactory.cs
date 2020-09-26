using System;
using System.Diagnostics;

namespace Raiding
{
    public class HeroFactory
    {
        public static BaseHero GetHero(string hero, string name)
        {
            if (hero == nameof(Druid))
            {
                return new Druid(name);
            }
            else if (hero == nameof(Paladin))
            {
                return new Paladin(name);
            }
            else if (hero == nameof(Rogue))
            {
                return new Rogue(name);
            }
            else if (hero == nameof(Warrior))
            {
                return new Warrior(name);
            }

            throw new ArgumentException("Invalid hero!");
        }
    }
}