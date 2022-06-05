using System;

namespace LittleDelights.Common
{
    public class Constants
    {
        public class ItemPrices
        {
            public const double Milk = 3.7;
            public const double Fish = 5;
            public const double RedWine = 5;
            public const double SparklingWine = 7;
            public const double WineMaxPrice = 200;
        }

        public class ItemNames
        {
            public const string Milk = "Milk";
            public const string Fish = "Fish";
            public const string WineRed = "Red Wine";
            public const string WineSparkling = "Sparkling Wine";
            public const string Total = "Total";
        }

        public class ErrorMessages
        {
            public const string WineTypeNotExist = "Wrong wine type";
        }
    }
}
