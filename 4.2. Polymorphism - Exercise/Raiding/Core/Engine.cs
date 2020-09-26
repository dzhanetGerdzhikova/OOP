using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Engine
    {
        private ICollection<BaseHero> heroes;

        public Engine()
        {
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                string name = Console.ReadLine();
                string typeHero = Console.ReadLine();
                try
                {
                    BaseHero currentHero = HeroFactory.GetHero(typeHero, name);
                    heroes.Add(currentHero);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            heroes.ToList().ForEach(x => Console.WriteLine(x.CastAbility()));
            int bossPower = int.Parse(Console.ReadLine());

            int sumPower = heroes.Select(h => h.Power).Sum();
            if (sumPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}