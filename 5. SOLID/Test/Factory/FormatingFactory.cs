using System;
using System.Collections.Generic;
using System.Text;
using SOLID.TypeFormating;

namespace SOLID.Factory
{
  public static  class FormatingFactory
    {
        public static IFormating CreateFormat(string typeFormat)
        {
            if(typeFormat == nameof(SimpleFormating))
            {
                return new SimpleFormating();
            }
            else if(typeFormat==nameof(XmlFormating))
                {
                return new XmlFormating();
            }
            return null;
        }
    }
}
