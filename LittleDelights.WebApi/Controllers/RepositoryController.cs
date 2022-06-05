using LittleDelights.Contract.Interfaces;
using LittleDelights.Data.Repositories;
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
    public class ItemController : ControllerBase
    {
        private readonly ItemRepository itemRepository;
        private readonly ILogger<CartController> _logger;

        public ItemController(ItemRepository itemRepository, ILogger<CartController> logger)
        {
            this.itemRepository = itemRepository;
            _logger = logger;
        }

        /// <summary>
        /// Retreive the list of items
        /// </summary>
        [HttpGet("[action]")]
        public ActionResult GetItems()
        {
            try
            {
                return Ok(itemRepository.GetItems());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return this.BadRequest();
            }
        }
    }
}
