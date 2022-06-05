using System;

namespace LittleDelights.Common
{
    public class Constants
    {
        public class StartPrice
        {
            public const decimal Milk = 3.7m;
            public const decimal Fish = 5;
            public const decimal RedWine = 5;
            public const decimal SparklingWine = 7;
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
