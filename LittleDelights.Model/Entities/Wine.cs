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
        public Wine(DateTime producedOn, WineType type)
        {
            ProducedOn = producedOn;
            StartPrice = type switch
            {
                WineType.Red => Constants.StartPrice.RedWine,
                WineType.Sparkling => Constants.StartPrice.SparklingWine,
                _ => throw new NotImplementedException(), // todo: vg
            };
        }

        public DateTime ProducedOn { get; }

        public override decimal GetPrice(DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}
