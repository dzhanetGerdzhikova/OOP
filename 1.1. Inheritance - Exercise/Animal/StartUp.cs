using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string typeOfAnimal = Console.ReadLine();

            while (typeOfAnimal != "Beast!")
            {
                string[] info = Console.ReadLine().Split(' ').ToArray();
                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];
                try
                {
                    Animal animal = null;
                    if (typeOfAnimal == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (typeOfAnimal == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (typeOfAnimal == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (typeOfAnimal == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (typeOfAnimal == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    animals.Add(animal);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                typeOfAnimal = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}