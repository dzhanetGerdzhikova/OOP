using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
   public class Student
    {
        private string name;
        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value=="Gin4o")
                {
                    throw new InvalidPersonNameException("The name connot be Gin4o.");
                }
            }
        }
        public string Email { get; set; }
    }
}
