using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal price, int days, Season season, Discount discount=0)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;
            decimal totalPrice = ((price * days) * multiplier) * (1- discountMultiplier);
            return totalPrice;
        }
    }
}
