using LittleDelights.Common;
using LittleDelights.Contract.Interfaces;
using LittleDelights.Contract.Model;
using LittleDelights.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Services
{
    public class Checkout : ICheckout
    {
        private readonly ItemRepository itemRepository;

        public DateTime CreatedOn { get; }

        public List<ReceiptLine> Receipt { get; set; }

        public Checkout(ItemRepository itemRepository, DateTime createdOn)
        {
            this.itemRepository = itemRepository;
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
