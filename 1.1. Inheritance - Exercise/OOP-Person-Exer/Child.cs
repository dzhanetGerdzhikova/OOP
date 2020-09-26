namespace OOP_Person_Exer
{
    public class Child : Person
    {
        private int age;

        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get { return this.age; }
            set
            {
                if (value < 16)
                {
                    this.age = value;
                }
            }
        }
    }
}