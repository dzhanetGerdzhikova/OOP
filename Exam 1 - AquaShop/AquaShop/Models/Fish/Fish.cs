using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private decimal price;
        private string species;
        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => name;
           private  set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }
                name = value;
            }
        }

        public decimal Price
        {
            get => price;
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }
                price = value;
            }
        }

        public int Size { get; protected set; }

        public string Species
        {
            get => species;
           private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }
                species = value;
            }
        }
        public abstract void Eat();
    }
}