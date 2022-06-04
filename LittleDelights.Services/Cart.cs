using LittleDelights.Contract.Interfaces;
using LittleDelights.Data.Contract.Repositories;
using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;

namespace LittleDelights.Model.Services
{
    public class Cart : ICart
    {
        private readonly IItemRepository itemRepository;

        public Cart(IItemRepository itemRepository)
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
