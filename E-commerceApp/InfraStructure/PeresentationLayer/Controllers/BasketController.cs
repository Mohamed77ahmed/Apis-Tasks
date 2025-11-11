using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using ServiceAbstraction;
using Shared.DTOS.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServiceManager _serviceManager): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CustomerBasketDto>> GetBasket(string key)
        {
            var basket= await _serviceManager.BasketService.GetBasketAsync(key);
            return Ok(basket);
                
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string key)
        {
            var basket = await _serviceManager.BasketService.DeleteBasketAsync(key);
            return Ok(basket);

        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdateBasket(CustomerBasketDto  customerBasket)
        {
            var basket = await _serviceManager.BasketService.CreateOrUpdateBasketAsync(customerBasket);
            return Ok(basket);

        }

    }
}
