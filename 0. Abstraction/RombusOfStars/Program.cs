using System;
using System.Text;

namespace SingleInheritance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int sizeOfRhombus = int.Parse(Console.ReadLine());
            PrintRhombusPart(sizeOfRhombus, true);
            PrintRhombusPart(sizeOfRhombus, false);
        }

        private static void PrintRhombusPart(int size, bool isTop)
        {
            for (int row = 1; row < size; row++)
            {
                int numberOfStars = isTop ? row : size - row;
                int numberOfSpaces = isTop ? size - row : row;

                PrintRow(numberOfSpaces, numberOfStars);
            }
        }

        public static void PrintRow(int numberOfSpaces, int numberOfStars)
        {
            Console.WriteLine(new string(' ', numberOfSpaces) + GetFormatedStars(numberOfStars));
        }

        public static string GetFormatedStars(int numberStars)
        {
            StringBuilder stars = new StringBuilder();

            for (int j = 1; j <= numberStars; j++)
            {
                stars.Append("* ");
            }
            return stars.ToString();
        }
    }
}