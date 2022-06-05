using LittleDelights.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleDelights.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICart cart;
        private readonly ILogger<CartController> _logger;

        public CartController(ICart cart, ILogger<CartController> logger)
        {
            this.cart = cart;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new item into the shopping cart
        /// </summary>
        /// <param name="itemId">the item identifier</param>
        /// <param name="quantity">how many of this item should be added</param>
        [HttpPut]
        public ActionResult AddItem(Guid id, int quantity)
        {
            try
            {
                cart.AddItem(id, quantity);
                return this.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Retreive cart item ids and quantities
        /// </summary>
        [HttpGet]
        public ActionResult GetItems()
        {
            try
            {
                return Ok(cart.Items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }
    }
}
