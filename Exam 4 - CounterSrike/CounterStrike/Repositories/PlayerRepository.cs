using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private ICollection<IPlayer> models;
        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => this.models.ToList().AsReadOnly();

        public void Add(IPlayer model)
        {
            if(model==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.models.FirstOrDefault(pl => pl.Username == name);
        }

        public bool Remove(IPlayer model)
        {
           return this.models.Remove(model);
        }
    }
}
