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
        private readonly ItemRepository itemRepository;

        public Cart(ItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public List<CartItem> CartItems { get; set; }

        public void AddItem(Guid itemId, int quantity)
        {
            // add an item to the cart
            // what if item doesn't exist in items repo?
            // what if item is already in the cart? - add it again

            var item = itemRepository.GetItem(itemId);

            throw new NotImplementedException();
        }
    }
}
