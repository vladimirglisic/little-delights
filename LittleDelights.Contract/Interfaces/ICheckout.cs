using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Contract.Interfaces
{
    public interface ICheckout
    {
        DateTime CreatedOn { get; }

        List<ReceiptLine> Receipt { get; set; }

        /// <summary>
        /// Creates a receipt for all items of the shopping cart
        /// </summary>
        /// <param name="cart">the shopping cart</param>
        void CreateReceipt(ICart cart);
    }
}
