using LittleDelights.Contract;
using System;
using System.Collections.Generic;

namespace LittleDelights.Model
{
    public class Chart : ICart
    {
        public Guid Id { get; set; }

        public virtual ICollection<ChartItem> ChartItems { get; set; }

        public void AddItem(Guid itemId, int quantity)
        {
            // add an item to the chart
            // what if item doesn't exist in items repo?
            // what if item is already in the chart?
            throw new NotImplementedException();
        }
    }
}
