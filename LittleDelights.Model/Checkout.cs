using LittleDelights.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model
{
    public class Checkout : ICheckout
    {
        public Guid Id { get; set; }

        public Guid ChartId { get; set; }

        public virtual Chart Chart { get; set; }

        public void CreateReceipt(ICart cart)
        {
            // create new checkout in the repository

            throw new NotImplementedException();
        }
    }
}
