﻿using System;

namespace OOP_Person_Exer
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Person person;
            if(age<16)
            {
                person=new Child(name,age);
            }
            else
            {
                person = new Person(name, age);
            }
            Console.WriteLine(person);
        }
    }
}
