using Farm.Models.Food;

namespace Farm.Factory
{
    public static class FactoryFood
    {
        public static Food CreateFood(string typeFood, int quantity)
        {
            if (typeFood == nameof(Fruit))
            {
                return new Fruit(quantity);
            }
            else if (typeFood == nameof(Meat))
            { 
                return new Meat(quantity);
            }
            else if (typeFood == nameof(Seeds))
            {
                return new Seeds(quantity);
            }
            else if (typeFood == nameof(Vegetable))
            {
                return new Vegetable(quantity);
            }
            return null;
        }
    }
}