using Farm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;


namespace Farm.Models.Animal
{
    public class Mouse : Mammal
    {
        private double weightPerUnit = 0.10;
        private List<string > miceFood= new List<string>()
            {
                {"vegetable"},
                {"fruit"}
            };
        public Mouse(string name, double weight,string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food.Food food)
        {
            base.Eat(food, weightPerUnit, miceFood);
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
