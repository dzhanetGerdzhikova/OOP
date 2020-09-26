using CounterStrike.Core.Factory;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CounterStrike.Core.Contracts
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> gunsRepo;
        private readonly IRepository<IPlayer> playersRepo;

        public Controller()
        {
            this.gunsRepo = new GunRepository();
            this.playersRepo = new PlayerRepository();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun currentGun = GunFactory.CreateGun(type, name, bulletsCount);
            if (currentGun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            gunsRepo.Add(currentGun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun currentGun = gunsRepo.FindByName(gunName);
            if (currentGun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            IPlayer currentPlayer = PlayerFactory.CreatePlayer(type, username, health, armor, currentGun);
            if (currentPlayer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            playersRepo.Add(currentPlayer);
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var finalList = playersRepo.Models.OrderBy(pl => pl.GetType().Name).ThenByDescending(pl => pl.Health).ThenBy(pl => pl.Username);

         //return  finalList.ToList().ForEach(pl=>pl.ToString())

            foreach (var player in finalList)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            Map map = new Map();
            string result = map.Start(playersRepo.Models.Where(pl => pl.IsAlive).ToList());
            return result;
        }
    }
}