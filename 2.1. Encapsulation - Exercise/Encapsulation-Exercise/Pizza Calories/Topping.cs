using System;
using System.Collections.Generic;

namespace Pizza_Calories
{
    public class Topping
    {
        private static IReadOnlyDictionary<string, double> toppingType = new Dictionary<string, double>()
        {
            { "meat",1.2},
            { "veggies",0.8},
            {"cheese",1.1 },
            { "sauce",0.9}
        };

        private string topping;
        private double weight;
        public Topping(string typeTopping, double weight)
        {
            this.ToppingType = typeTopping;
            this.Weight = weight;
        }
        public string ToppingType
        {
            get { return this.topping; }
            set
            {
                if (!toppingType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.topping = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }

            set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public double CalculatorOfCalories()
        {
            return 2 * this.weight * toppingType[this.ToppingType.ToLower()];
        }
    }
}