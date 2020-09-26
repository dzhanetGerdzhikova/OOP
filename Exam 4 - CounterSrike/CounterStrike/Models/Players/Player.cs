using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get => this.username;
            private set
            {
                this.username = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException(ExceptionMessages.InvalidPlayerName) : value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                this.health = value < 0 ? throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth) : value;
            }
        }

        public int Armor
        {
            get => this.armor;
            private set
            {
                this.armor = value < 0 ? throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor) : value;
            }
        }

        public IGun Gun
        {
            get => this.gun;
            private set
            {
                this.gun = value == null ? throw new ArgumentException(ExceptionMessages.InvalidGun) : value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            int damageTakenAfterArmor = Armor - points;
            Armor = Math.Max(damageTakenAfterArmor, 0); // 70 - 80, 0
            if (Armor == 0)
            {
                Health = Math.Max(Health - Math.Abs(damageTakenAfterArmor), 0);
            }

            //int initialArmor = Armor;
            //initialArmor -= points;

            //if (initialArmor < 0)
            //{
            //    Armor = 0;
            //    int initialHealth = Health;
            //    initialHealth -= Math.Abs(initialArmor);

            //    if (initialHealth < 0)
            //    {
            //        Health = 0;
            //    }
            //    else
            //    {
            //        Health = initialHealth;
            //    }
            //}
            //else
            //{
            //    Armor = initialArmor;
            //}
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");
            return sb.ToString().TrimEnd();
        }
    }
}