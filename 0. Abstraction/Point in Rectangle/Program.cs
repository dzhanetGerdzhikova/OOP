using System;
using System.Linq;

namespace PointinRectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Point left = new Point(coordinates[0], coordinates[1]);
            Point right = new Point(coordinates[2], coordinates[3]);
            Rectangle rectangle = new Rectangle(left, right);
            int countInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countInputs; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Point currentPoint = new Point(input[0], input[1]);
                Console.WriteLine(rectangle.Contains(currentPoint));
            }
        }
    }
}