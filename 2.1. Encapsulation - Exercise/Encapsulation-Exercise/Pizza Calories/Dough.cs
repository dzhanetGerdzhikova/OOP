using System;
using System.Collections.Generic;

namespace Pizza_Calories
{
    public class Dough
    {
        private static IReadOnlyDictionary<string, double> typeOfDough = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain",1.0}
        };

        private static IReadOnlyDictionary<string, double> typeOfTechnique = new Dictionary<string, double>
        {
            { "crispy",0.9},
            {"chewy",1.1 },
            {"homemade",1.0 }
        };

        private string doughType;
        private string technique;
        private double weight;

        public Dough(string dough, string technique, double weight)
        {
            this.DoughType = dough;
            this.Technique = technique;
            this.Weight = weight;
        }

        public string DoughType
        {
            get
            {
                return this.doughType;
            }
            private set
            {
                if (!typeOfDough.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.doughType = value;
            }
        }

        public string Technique
        {
            get
            {
                return this.technique;
            }
            private set
            {
                if (!typeOfTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.technique = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double CalculatorOfCalories()
        {
            return 2 * this.Weight * typeOfDough[this.DoughType.ToLower()] * typeOfTechnique[this.Technique.ToLower()];
        }
    }
}