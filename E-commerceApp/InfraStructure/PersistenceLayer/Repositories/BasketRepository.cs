using DomainLayer.Contracts;
using DomainLayer.Models.BasketModels;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class BasketRepository(IConnectionMultiplexer _connection) : IBasketRepository
    {
        private readonly IDatabase _database=_connection.GetDatabase(); 
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket customerBasket, TimeSpan? timeTolive = null)
        {
           var JsonBaket=JsonSerializer.Serialize(customerBasket);
           var isCreatedOrUpdated=await _database.StringSetAsync(customerBasket.Id, JsonBaket, timeTolive ?? TimeSpan.FromDays(30));
            if (isCreatedOrUpdated) return customerBasket;
            else return null;   
        }

        public async Task<bool> DeleteBasketAsync(string Key)
        => await _database.KeyDeleteAsync(Key);

        public async Task<CustomerBasket?> GetBasketAsync(string Key)
        {
           var basket=await _database.StringGetAsync(Key);  
            if(basket.IsNullOrEmpty)return null;
            else
                return JsonSerializer.Deserialize<CustomerBasket>(basket!);  
        }
    }
}
