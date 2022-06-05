using LittleDelights.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public class Milk : Item
    {
        public override string Name => Constants.ItemNames.Milk;

        public Milk(DateTime bestBefore)
        {
            BestBefore = bestBefore;
            StartPrice = Constants.ItemPrices.Milk;
        }

        public DateTime BestBefore { get; }

        public override double CalculatePrice(DateTime now)
        {
            int diff = (now.Date - BestBefore.Date).Days;
            double price = StartPrice;
            for (int i = 0; i < diff; i++)
            {
                if (i == 0) price *= .5;
                else price *= .85; // -15%
            }
            return price;
        }
    }
}
