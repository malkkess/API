using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfetObject.BasketMouldeDtos;

namespace ServiceAbsrt
{
    public interface IBasketService
    {
        Task<BasketDtos> GetbasketAsync(string Key);
        Task<BasketDtos> CreateOrUpdateBasketAsync(BasketDtos basket);
        Task<bool> DeletBasketAsync(string Key);
    }
}
