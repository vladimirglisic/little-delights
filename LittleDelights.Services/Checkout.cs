using LittleDelights.Common;
using LittleDelights.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public class Checkout : ICheckout
    {
        public DateTime CreatedOn { get; }

        public List<ReceiptLine> Receipt { get; set; }

        public Checkout(DateTime createdOn)
        {
            CreatedOn = createdOn;
        }

        public void CreateReceipt(ICart cart)
        {
            Receipt = new List<ReceiptLine>();

            foreach(var cartItem in cart.CartItems)
            {
                Receipt.Add(new ReceiptLine(cartItem.Item.Name, cartItem.Quantity * cartItem.Item.GetPrice(CreatedOn)));
            }

            Receipt.Add(new ReceiptLine(Constants.ItemNames.Total, Receipt.Sum(x => x.Price)));
        }
    }
}
