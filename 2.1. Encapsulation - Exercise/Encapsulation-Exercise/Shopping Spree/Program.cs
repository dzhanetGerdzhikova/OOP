using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                string[] peopleInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < peopleInfo.Length; i++)
                {
                    string[] currentInfo = peopleInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = currentInfo[0];
                    decimal money = decimal.Parse(currentInfo[1]);
                    Person person = new Person(name, money);
                    people.Add(person);
                }

                string[] productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productsInfo.Length; i++)
                {
                    string[] currentInfo = productsInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = currentInfo[0];
                    decimal cost = decimal.Parse(currentInfo[1]);
                    Product product = new Product(name, cost);
                    products.Add(product);
                }

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] splitedInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = splitedInfo[0];
                    string product = splitedInfo[1];
                    Person currentPerson = people.FirstOrDefault(p => p.Name == name);
                    Product currentProduct = products.FirstOrDefault(pro => pro.Name == product);
                    currentPerson.AddInBag(currentProduct);

                    input = Console.ReadLine();
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}