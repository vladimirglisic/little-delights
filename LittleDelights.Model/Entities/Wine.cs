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
        public Wine(DateTime producedOn, WineCategory category)
        {
            ProducedOn = producedOn;
            StartPrice = category switch
            {
                WineCategory.Red => Constants.StartPrice.RedWine,
                WineCategory.Sparkling => Constants.StartPrice.SparklingWine,
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
