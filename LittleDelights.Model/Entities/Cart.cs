using LittleDelights.Contract;
using System;
using System.Collections.Generic;

namespace LittleDelights.Model.Entities
{
    public class Cart : ICart
    {
        public Guid Id { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public void AddItem(Guid itemId, int quantity)
        {
            // add an item to the cart
            // what if item doesn't exist in items repo?
            // what if item is already in the cart?
            throw new NotImplementedException();
        }
    }
}
