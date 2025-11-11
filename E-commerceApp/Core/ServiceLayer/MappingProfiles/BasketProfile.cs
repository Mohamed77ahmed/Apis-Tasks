using AutoMapper;
using DomainLayer.Models.BasketModels;
using Shared.DTOS.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.MappingProfiles
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket,CustomerBasketDto >().ReverseMap();
            CreateMap<BasketItem,BasketItemDto >().ReverseMap();
        }

    }
}
