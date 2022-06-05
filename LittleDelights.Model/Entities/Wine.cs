using LittleDelights.Common;
using LittleDelights.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public class Wine : Item
    {
        private WineType type;

        public override string Name => type switch
        {
            WineType.Red => Constants.ItemNames.WineRed,
            WineType.Sparkling => Constants.ItemNames.WineSparkling,
            _ => throw new ArgumentException(Constants.ErrorMessages.WineTypeNotExist),
        };

        public Wine(DateTime producedOn, WineType type)
        {
            ProducedOn = producedOn;
            this.type = type;
            StartPrice = type switch
            {
                WineType.Red => Constants.StartPrice.RedWine,
                WineType.Sparkling => Constants.StartPrice.SparklingWine,
                _ => throw new ArgumentException(Constants.ErrorMessages.WineTypeNotExist),
            };
        }

        public DateTime ProducedOn { get; }

        public override decimal GetPrice(DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}
