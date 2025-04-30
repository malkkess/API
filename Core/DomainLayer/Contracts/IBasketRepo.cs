using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.BasketModels;

namespace DomainLayer.Contracts
{
    public interface IBasketRepo
    {
        Task<CustomerBasket?> GetBasketAsync(String Key);
        Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TimeToLive = null);
        Task<bool> DeleteBasketAsync(string id);
    }
}
