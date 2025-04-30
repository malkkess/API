using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAbsrt;
using Shared.DataTransfetObject.BasketMouldeDtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServiceManger serviceManger):ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BasketDtos>>GetBasket(string Key)
        {
            var Basket =await serviceManger.BasketService.GetbasketAsync(Key);
            return Ok(Basket);
        }
        [HttpPost]
        public async Task<ActionResult<BasketDtos>>CretaeOrUpdaetBasket(BasketDtos basket)
        {
            var Basket = await serviceManger.BasketService.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket);
        }
        [HttpDelete("{Key}")]
        public async Task <ActionResult<bool>>DeleteBasket(string Key)
        {
            var Result= await serviceManger.BasketService.DeletBasketAsync(Key);
            return Ok(Result);
        }
    }
}
