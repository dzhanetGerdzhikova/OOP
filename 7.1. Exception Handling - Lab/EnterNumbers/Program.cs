using System;

namespace EnterNumbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int countLines = 10;
            try
            {
                for (int i = 0; i < countLines; i++)
                {
                    ReadNumber(1, 100);
                }
            }
            catch (Exception ex)
            when (ex is FormatException || ex is IndexOutOfRangeException)
            {
                Console.WriteLine("Number is not at range or is invalid format.");
            }
        }

        public static void ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new IndexOutOfRangeException($"Number must be at range [{start} - {end}]");
            }
        }
    }
}