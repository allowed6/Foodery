using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Common
{
    public static class EntityValidationConstants
    {
        public static class Category 
        {
            public const int CategoryNameMinLength = 2;
            public const int CategoryNameMaxLength = 50;
        }

        public static class Product 
        {
            public const int ProductNameMinLength = 3;
            public const int ProductNameMaxLength = 50;

            public const int ProductDescriptionMinLength = 15;
            public const int ProductDescriptionMaxLength = 250;

            public const int ImageUrlMaxLength = 2048;

            public const string ProductPriceMinValue = "0";
            public const string ProductPriceMaxValue = "2000";
        }
    }
}
