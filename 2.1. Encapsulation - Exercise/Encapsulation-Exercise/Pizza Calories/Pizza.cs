using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough) : this(name)
        {
            this.Dough = dough;
        }

        public Pizza(string name)
        {
            this.Name = name;
            toppings = new List<Topping>();
        }

        public Dough Dough { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 0 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public double PizzaCalories => this.Dough.CalculatorOfCalories() + this.toppings.Select(e => e.CalculatorOfCalories()).Sum();

        public int ToppingsCount => toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (ToppingsCount > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {PizzaCalories:f2} Calories.";
        }
    }
}