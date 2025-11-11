using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.BasketModels;
using ServiceAbstraction;
using Shared.DTOS.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BasketService(IBasketRepository _basketRepository,IMapper _mapper) : IBasketService
    {
        public async Task<CustomerBasketDto> CreateOrUpdateBasketAsync(CustomerBasketDto customerBasket)
        {
            var mapCustomerBasket=_mapper.Map<CustomerBasket>(customerBasket);
            var CreatedOrUpdated= await _basketRepository.CreateOrUpdateBasketAsync(mapCustomerBasket);
            if (CreatedOrUpdated != null) return await GetBasketAsync(customerBasket.Id);
            else throw new Exception("Can't Add or Update Basket ,Try Again ");
          
        }

        public async Task<bool> DeleteBasketAsync(string key)
       =>await _basketRepository.DeleteBasketAsync(key);

        public async Task<CustomerBasketDto> GetBasketAsync(string key)
        {
           var basket= await _basketRepository.GetBasketAsync(key);
            if (basket is not null) return _mapper.Map<CustomerBasketDto>(basket);
            else throw new BasketNotFoundException(key);
        }
    }
}
