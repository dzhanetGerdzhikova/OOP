using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value.Length>1)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }
       public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(value>=0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }
       public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if(value=="Female" || value =="Male")
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentException("Inavalid input!");
                }
            }
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name}");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            result.AppendLine($"{this.ProduceSound()}");

            return result.ToString().TrimEnd();
        }
    }
}
