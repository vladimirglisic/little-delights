using LittleDelights.Contract.Interfaces;
using LittleDelights.Contract.Model;
using LittleDelights.Data.Repositories;
using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;

namespace LittleDelights.Services
{
    public class Cart : ICart
    {
        public Dictionary<Guid, int> Items { get; set; } = new Dictionary<Guid, int>();

        public void AddItem(Guid itemId, int quantity)
        {
            // if item is already in the cart, add quantity to existing item
            if (Items.ContainsKey(itemId))
            {
                Items[itemId] = Items[itemId] + quantity;
                return;
            }

            Items[itemId] = quantity;
        }
    }
}
