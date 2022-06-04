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
            StartPrice = Constants.StartPrice.Milk;
        }

        public DateTime BestBefore { get; }

        public override decimal GetPrice(DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}
