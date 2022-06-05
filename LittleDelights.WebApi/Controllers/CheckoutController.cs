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
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckout checkout;
        private readonly ILogger<CartController> _logger;

        public CheckoutController(ICheckout checkout, ILogger<CartController> logger)
        {
            this.checkout = checkout;
            _logger = logger;
        }

        /// <summary>
        /// Creates a receipt for all items of the shopping cart
        /// </summary>
        /// <param name="cart">the shopping cart</param>
        [HttpPost]
        public ActionResult CreateReceipt(ICart cart)
        {
            try
            {
                checkout.CreateReceipt(cart);
                return this.Ok(new
                {
                    Data = checkout.Receipt,
                    Text = checkout.ToString(),
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }
    }
}
