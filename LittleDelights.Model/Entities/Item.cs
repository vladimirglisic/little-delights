using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public abstract class Item
    {
        public abstract string Name { get; }

        public double StartPrice { get; set; }

        public abstract double CalculatePrice(DateTime now);
    }
}
