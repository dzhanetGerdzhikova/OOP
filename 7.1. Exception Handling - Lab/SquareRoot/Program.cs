using System;

namespace SquareRoot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                double number = double.Parse(Console.ReadLine());
                if(number<0)
                {
                    throw new ArgumentException( "Number cannot be negative.", nameof(number));
                }
                double result = Math.Sqrt(number);
                Console.WriteLine(result);
            }
            catch (Exception ex)
          when (ex is FormatException || ex is ArgumentException)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
    }
}