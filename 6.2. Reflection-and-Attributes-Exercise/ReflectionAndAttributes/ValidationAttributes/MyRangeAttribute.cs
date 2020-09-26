using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int min, int max)
        {
            minValue = min;
            maxValue = max;
        }

        public override bool IsValid(object obj)
        {
            if (obj is int objAsInt)
            {
                return objAsInt >= minValue && objAsInt <= maxValue;
            }
            throw new ArgumentException($"{obj} is not {nameof(Int32)}");
        }
    }
}
