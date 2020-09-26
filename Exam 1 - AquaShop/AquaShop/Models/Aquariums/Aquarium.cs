using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium, IEnumerable
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }

        public string Name
        {
            get => name; private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity { get; protected set; }

        public int Comfort => this.Decorations.Select(d => d.Comfort).Sum();

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity > this.Fish.Count)
            {
                this.Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var fish in this.Fish)
            {
                yield return fish;
            }
        }

        public string GetInfo()
        {
            StringBuilder result = new StringBuilder();
            string fishesInfo = this.Fish.Count == 0 ? "none" : string.Join(", ", this.Fish.Select(f => f.Name));
          
            result.AppendLine($"{this.Name} ({this.GetType().Name}):");
            result.AppendLine($"Fish: {fishesInfo}");
            result.AppendLine($"Decorations: {this.Decorations.Count()}");
            result.AppendLine($"Comfort: {this.Comfort}");

            return result.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);
    }
}