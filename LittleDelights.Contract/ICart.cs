using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Contract
{
    public interface ICart
    {
        List<CartItem> CartItems { get; set; }

        /// <summary>
        /// Adds a new item into the shopping cart
        /// </summary>
        /// <param name="itemId">the item identifier</param>
        /// <param name="quantity">how many of this item should be added</param>
        void AddItem(Guid itemId, int quantity);
    }
}
