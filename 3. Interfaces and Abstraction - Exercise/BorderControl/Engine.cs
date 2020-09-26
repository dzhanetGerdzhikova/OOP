using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Engine
    {
        public void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ');
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (personInfo.Length == 4)
                {
                    string id = personInfo[2];
                    DateTime birthdate = DateTime.Parse(personInfo[3]);
                    IBuyer citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else
                {
                    string group = personInfo[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }
            string nameOfPerson = Console.ReadLine();

            while (nameOfPerson != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == nameOfPerson);
                if (buyer == null)
                {
                    nameOfPerson = Console.ReadLine();
                    continue;
                }

                buyer.BuyFood();

                nameOfPerson = Console.ReadLine();
            }

            int totalFood = buyers.Select(b => b.Food).Sum();
            Console.WriteLine(totalFood);
        }
    }
}