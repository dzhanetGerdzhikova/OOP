using System;

namespace FixingVol2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int numOne = 30;
            int numTwo = 60;
            byte result = 0;
            try
            {
                result = Convert.ToByte(numOne * numTwo);
                Console.WriteLine($"{numOne} * {numTwo} = {result}");

            }
            catch (OverflowException)
            {
                Console.WriteLine("The result is not in corect type.");
            }

        }
    }
}