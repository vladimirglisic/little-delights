using LittleDelights.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public class Fish : Item
    {
        public override string Name => Constants.ItemNames.Fish;

        public Fish(DateTime capturedOn)
        {
            CapturedOn = capturedOn;
            StartPrice = Constants.ItemPrices.Fish;
        }

        public DateTime CapturedOn { get; }

        public override double CalculatePrice(DateTime now)
        {
            int diff = (now.Date - CapturedOn.Date).Days;
            double price = StartPrice;
            for (int i = 0; i < diff; i++)
            {
                price *= .9;
            }
            return price;
        }
    }
}
