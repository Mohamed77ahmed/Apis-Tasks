using Shared.DTOS.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IBasketService
    {
        public Task<CustomerBasketDto> GetBasketAsync(string key);
        public Task<CustomerBasketDto> CreateOrUpdateBasketAsync(CustomerBasketDto customerBasket);
        public Task<bool> DeleteBasketAsync(string key);
    }
}
