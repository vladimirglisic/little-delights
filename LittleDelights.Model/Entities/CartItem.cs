using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public class CartItem
    {
        public Guid CartId { get; set; }

        public Guid ItemId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Item Item { get; set; }
    }
}
