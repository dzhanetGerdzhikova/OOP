using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(p => p is Terrorist).ToList();
            var counterTerrorist = players.Where(p => p is CounterTerrorist).ToList();

            while (terrorists.Any(e => e.IsAlive) && counterTerrorist.Any(e => e.IsAlive))
            {
                foreach (var currentTerrorist in terrorists.Where(t => t.IsAlive))
                {
                    foreach (var currentCounterTerrorist in counterTerrorist.Where(t => t.IsAlive))
                    {
                        int fireBulletsOnTerrorist = currentTerrorist.Gun.Fire();
                        currentCounterTerrorist.TakeDamage(fireBulletsOnTerrorist);
                    }
                }
                foreach (var currentCounterTerrorist in counterTerrorist.Where(t => t.IsAlive))
                {
                    foreach (var currentTerrorist in terrorists.Where(t => t.IsAlive))
                    {
                        int fireBulletsOnCounterTerrorist = currentCounterTerrorist.Gun.Fire();
                        currentTerrorist.TakeDamage(fireBulletsOnCounterTerrorist);
                    }
                }
            }
            if (terrorists.Any(t => t.IsAlive))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }
        }
    }
}