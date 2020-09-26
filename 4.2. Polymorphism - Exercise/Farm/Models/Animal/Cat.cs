using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Models.Animal
{
    public class Cat : Feline
    {
        private double weightPerUnit = 0.30;
        private List<string> catsFood = new List<string>()
            {
                "vegetable",
                "meat"
            };
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food.Food food)
        {
            base.Eat(food, weightPerUnit, catsFood);
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
