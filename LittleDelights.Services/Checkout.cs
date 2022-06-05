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

        public DateTime CheckoutDate { get; }

        public List<ReceiptLine> Receipt { get; set; }

        public Checkout(ItemRepository itemRepository, DateTime now)
        {
            this.itemRepository = itemRepository;
            CheckoutDate = now;
        }

        public void CreateReceipt(ICart cart)
        {
            Receipt = new List<ReceiptLine>();

            foreach(var itemQuantity in cart.Items)
            {
                var item = itemRepository.GetItem(itemQuantity.Key);
                if (item == null)
                {
                    // log: item not found
                    continue;
                }
                Receipt.Add(new ReceiptLine(item.Name, itemQuantity.Value * item.CalculatePrice(CheckoutDate)));
            }

            Receipt.Add(new ReceiptLine(Constants.ItemNames.Total, Receipt.Sum(x => x.Price)));
        }
    }
}
