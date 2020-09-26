using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core.Factory
{
    public static class PlayerFactory
    {
        public static IPlayer CreatePlayer(string type, string userName, int health, int amor,IGun gun)
        {
            if(type==nameof(Terrorist))
            {
                return new Terrorist(userName, health, amor, gun);
            }
            else if(type==nameof(CounterTerrorist))
                {
                return new CounterTerrorist(userName, health, amor, gun);
            }
            return null;
        }
    }
}