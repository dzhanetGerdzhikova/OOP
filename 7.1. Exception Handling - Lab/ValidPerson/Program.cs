using System;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Person person = new Person("Pesho", "Peshev", 24);
                // Person person1 = new Person("", "Peshev", 24);
                //Person person2 = new Person("Pesho", null, 24);
                //Person person3 = new Person("Pesho", "Peshev", -24);
                Student student = new Student("Gin4o", "jhjhggggj");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(InvalidPersonNameException ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
