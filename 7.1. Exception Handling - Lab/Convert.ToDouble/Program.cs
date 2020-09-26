using System;
using System.Numerics;

namespace Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            //Double.MaxValue
            string input = Console.ReadLine();
            try
            {
                BigInteger bigValue = new BigInteger((Double.MaxValue * 100));
                double result = System.Convert.ToDouble(bigValue.ToString());
                Console.WriteLine(result);
            }
            catch (Exception ex)
            when (ex is FormatException || ex is OverflowException)
            {
                Console.WriteLine("Input is incorrect format of incorrect type.");
                throw;
            }

        }
    }
}
