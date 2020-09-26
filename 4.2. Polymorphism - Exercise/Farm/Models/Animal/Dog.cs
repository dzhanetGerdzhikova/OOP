using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Models.Animal
{
  public   class Dog : Mammal
    {
        private double weightPerUnit = 0.40;
        private List<string> dogsFood = new List<string>()
            {
                {"meat"}
            };
        public Dog(string name, double weight,string livingRegion )
            : base(name, weight,livingRegion)
        {
        }

        public override void Eat(Food.Food food)
        {
            base.Eat(food, weightPerUnit, dogsFood);
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
