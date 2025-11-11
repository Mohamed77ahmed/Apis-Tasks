using DomainLayer.Models.BasketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts
{
    public interface IBasketRepository
    {
        public Task<CustomerBasket?>GetBasketAsync(string Key);
        public Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket customerBasket ,TimeSpan ?timeTolive=null);
        public Task<bool>DeleteBasketAsync(string Key);
        
    }
}
