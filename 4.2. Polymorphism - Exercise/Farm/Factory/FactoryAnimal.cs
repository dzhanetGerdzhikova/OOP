using Farm.Models.Animal;

namespace Farm.Factory
{
    public static class FactoryAnimal
    {
        public static Animal CreateAnimal(string[] animalInfo)
        {
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            if (animalInfo[0] == "Cat")
            {
                return new Cat(name, weight, animalInfo[3], animalInfo[4]);
            }
            else if (animalInfo[0] == "Dog")
            {
                return new Dog(name, weight, animalInfo[3]);
            }
            else if (animalInfo[0] == "Hen")
            {
                return new Hen(name, weight, double.Parse(animalInfo[3]));
            }
            else if (animalInfo[0] == "Mouse")
            {
                return new Mouse(name, weight, animalInfo[3]);
            }
            else if (animalInfo[0] == "Owl")
            {
                return new Owl(name, weight, double.Parse(animalInfo[3]));
            }
            else if (animalInfo[0] == "Tiger")
            {
                return new Tiger(name, weight, animalInfo[3], animalInfo[4]);
            }
            return null;
        }
    }
}