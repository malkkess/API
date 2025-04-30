using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.BasketModels;
using ServiceAbsrt;
using Shared.DataTransfetObject.BasketMouldeDtos;

namespace Service
{
    public class BasketService(IBasketRepo basketRepo , IMapper mapper) : IBasketService
    {
        public async Task<BasketDtos> CreateOrUpdateBasketAsync(BasketDtos basket)
        {
            var CustomerBasket = mapper.Map<BasketDtos, CustomerBasket>(basket);
            var CreatedOrUpdated=await basketRepo.CreateOrUpdateBasketAsync(CustomerBasket);
            if (CreatedOrUpdated is not null)
                return await GetbasketAsync(basket.Id);
            else
                throw new Exception("Can Not Update Or Create");

        }

        public async Task<bool> DeletBasketAsync(string Key)=>await basketRepo.DeleteBasketAsync(Key);

        public async Task<BasketDtos> GetbasketAsync(string Key)
        {
            var Basket = await basketRepo.GetBasketAsync(Key);
            if (Basket is not null)
            {
                return mapper.Map<CustomerBasket, BasketDtos>(Basket);
            }
            else
                throw new BasketNotFoundExecption(Key);

        }
    }
}
