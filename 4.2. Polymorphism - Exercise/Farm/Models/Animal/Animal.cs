using Farm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Models.Animal
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public double EatenFood { get; set; }
        public abstract string ProduceSound();
        protected void Eat(Food.Food food, double weightPerUnit, List<string> availableFoods)
        {
            if (availableFoods.Contains(food.GetType().Name.ToLower()))
            {
                this.Weight += food.Quantity * weightPerUnit;
                this.EatenFood += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public abstract void Eat(Food.Food food);
    }
}
