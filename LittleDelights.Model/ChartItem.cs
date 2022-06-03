using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model
{
    public class ChartItem
    {
        public Guid ChartId { get; set; }

        public Guid ItemId { get; set; }

        public virtual Chart Chart { get; set; }

        public virtual Item Item { get; set; }
    }
}
