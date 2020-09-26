using System;

namespace Pizza_Calories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split(' ')[1];
                Pizza pizza = new Pizza(pizzaName);

                string[] doughInfo = Console.ReadLine().Split(' ');
                string doughType = doughInfo[1];
                string technique = doughInfo[2];
                double weight = double.Parse(doughInfo[3]);
                Dough dough = new Dough(doughType, technique, weight);
                pizza.Dough = dough;

                string[] toppingInfo = Console.ReadLine().Split(' ');

                while (toppingInfo[0] != "END")
                {
                    string typeTopping = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(typeTopping, toppingWeight);
                    pizza.AddTopping(topping);
                    toppingInfo = Console.ReadLine().Split(' ');
                }
                
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}