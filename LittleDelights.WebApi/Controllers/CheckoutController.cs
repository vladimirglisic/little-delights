using LittleDelights.Contract.Interfaces;
using LittleDelights.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
        public ActionResult CreateReceipt(Cart cart)
        {
            try
            {
                checkout.CreateReceipt(cart);
                return this.Ok(checkout.Receipt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }
    }
}
