using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping
{
    public class Person
    {
        private string _name;
        private decimal _money;
        private List<Product> _bag;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this._bag = new List<Product>();
        }
        public IReadOnlyCollection<Product> Bag => this._bag.AsReadOnly();
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this._name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this._money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this._money = value;
            }
        }

        public void AddInBag(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this._bag.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            string bagProducts = Bag.Count > 0 ? string.Join(", ", Bag.Select(e => e.Name)) : "Nothing bought";
            return $"{this.Name} - {bagProducts}";
        }
    }
}
