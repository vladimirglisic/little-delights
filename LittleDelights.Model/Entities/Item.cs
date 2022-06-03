using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public abstract class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal StartPrice { get; set; }

        public abstract decimal GetPrice(DateTime now);
    }
}
