using LittleDelights.Contract;
using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;

namespace LittleDelights.Model.Services
{
    public class Cart : ICart
    {
        public List<CartItem> CartItems { get; set; }

        public void AddItem(Guid itemId, int quantity)
        {
            // add an item to the cart
            // what if item doesn't exist in items repo?
            // what if item is already in the cart? - add it again
            throw new NotImplementedException();
        }
    }
}
