using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Farm.Models.Animal
{
    public class Owl : Bird
    {
        private double weightPerUnit = 0.25;
        private List<string> ownsFood = new List<string>()
            {
                {"meat"}
            };
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food.Food food)
        {
            base.Eat(food, weightPerUnit, ownsFood);
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
