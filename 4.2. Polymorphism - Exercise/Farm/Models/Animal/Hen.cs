using Farm.Models.Food;
using System;
using System.Collections.Generic;

namespace Farm.Models.Animal
{
    public class Hen : Bird
    {
        private double weightPerUnit = 0.35;
        private List<string> hensFood = new List<string>()
        {
            nameof(Fruit),nameof(Meat),nameof(Seeds),nameof(Vegetable)
        };
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food.Food food)
        {
            base.Eat(food, weightPerUnit, hensFood);
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}