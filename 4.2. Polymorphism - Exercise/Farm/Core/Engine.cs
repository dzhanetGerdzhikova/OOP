using Farm.Factory;
using Farm.Models.Animal;
using Farm.Models.Food;
using System;
using System.Collections.Generic;

namespace Farm.Core
{
    public class Engine
    {
        ICollection<Animal> animals = null;;
        public Engine()
        {
            animals = new List<Animal>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            int counterLiness = 0;
            Animal currentAnimal = null;

            while (input != "End")
            {
                string[] splitedInput = input.Split(' ');
                if (counterLiness % 2 == 0)
                {
                    currentAnimal = FactoryAnimal.CreateAnimal(splitedInput);
                    if (currentAnimal != null)
                    {
                        animals.Add(currentAnimal);
                        Console.WriteLine(currentAnimal.ProduceSound());
                    }
                }
                else
                {
                    string typeFood = splitedInput[0];
                    int foodQuantity = int.Parse(splitedInput[1]);
                    try
                    {
                        Food currentFood = FactoryFood.CreateFood(typeFood, foodQuantity);
                        currentAnimal.Eat(currentFood);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                counterLiness++;
                input = Console.ReadLine();
            }
            animals.ForEach(a => Console.WriteLine(a));
        }
    }
}