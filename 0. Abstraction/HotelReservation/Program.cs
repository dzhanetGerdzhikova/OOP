using System;

namespace HotelReservation
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            decimal price = decimal.Parse(input[0]);
            int days = int.Parse(input[1]);
            string season = input[2];

            Enum.TryParse(season, out Season currentSeason);

            if (input.Length > 3)
            {
                string discount = input[3];
                Enum.TryParse(discount, out Discount currentDiscount);
                decimal totalPrice = PriceCalculator.GetTotalPrice(price, days, currentSeason, currentDiscount);
                Console.WriteLine(totalPrice);
            }
            else
            {
                decimal totalPrice = PriceCalculator.GetTotalPrice(price, days, currentSeason);
                Console.WriteLine(totalPrice);
            }

            //Season currentSeason = 0;
            //if (season == "Autumn")
            //{
            //    currentSeason = Season.Autumn;
            //}
            //else if (season == "Spring")
            //{
            //    currentSeason = Season.Spring;
            //}
            //else if (season == "Winter")
            //{
            //    currentSeason = Season.Winter;
            //}
            //else if (season == "Summer")
            //{
            //    currentSeason = Season.Summer;
            //}

            //Discount currentDiscount = 0;

            //if (input.Length > 3)
            //{
            //    string discount = input[3];
            //    if (discount == "VIP")
            //    {
            //        currentDiscount = Discount.vip;
            //    }
            //    else if (discount == "SecondVisit")
            //    {
            //        currentDiscount = Discount.secondVisit;
            //    }
            //}
            //else
            //{
            //    currentDiscount = Discount.none;
            //}
            //decimal totalPrice = PriceCalculator.GetTotalPrice(price, days, currentSeason, currentDiscount);
            //Console.WriteLine(totalPrice);
        }
    }
}