﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models.BasketModels;
using StackExchange.Redis;

namespace Presis.Repositories
{
    public class BasketRepo(IConnectionMultiplexer connection) : IBasketRepo
    {
        private readonly IDatabase _database=connection.GetDatabase();
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TimeToLive = null)
        {
            var JsonBasket =JsonSerializer.Serialize(basket);
            var IsCreatedOrUpdated= await _database.StringSetAsync(basket.Id,JsonBasket, TimeToLive?? TimeSpan.FromDays(30));
            if (IsCreatedOrUpdated) 
            {
                return await GetBasketAsync(basket.Id);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteBasketAsync(string id) => await _database.KeyDeleteAsync(id);

        public async Task<CustomerBasket?> GetBasketAsync(string Key)
        {
            var Basket = await _database.StringGetAsync(Key);
            if (Basket.IsNullOrEmpty)
                return null;
            else
                return JsonSerializer.Deserialize<CustomerBasket>(Basket!);
        }
    }
}
