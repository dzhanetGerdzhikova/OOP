using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Models.Animal
{
   public class Tiger : Feline
    {
        private double weightPerUnit = 1;
        private List<string> tigersFood = new List<string>()
            {
                {"meat"}
            };
        public Tiger(string name, double weight,string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food.Food food)
        {
            base.Eat(food, weightPerUnit, tigersFood);
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
