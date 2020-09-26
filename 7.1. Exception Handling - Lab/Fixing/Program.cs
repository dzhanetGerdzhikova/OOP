using System;

namespace Fixing
{
    internal class Program
{
    private static void Main(string[] args)
    {
        string[] weekDays = new string[]
        {
               "Sunday",
              "Monday",
              "Tuesday",
              "Wednesday",
              "Thursday"
        };
        try
        {
            for (int i = 0; i <= 5; i++)
            {
                System.Console.WriteLine(weekDays[i]);
            }
        }
        catch (IndexOutOfRangeException)
        {
                Console.WriteLine("Index was out of the array range.");
        }
    }
}
}