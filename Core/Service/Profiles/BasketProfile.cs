using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Models.BasketModels;
using Shared.DataTransfetObject.BasketMouldeDtos;

namespace Service.Profiles
{
    public class BasketProfile: Profile
    {
        public BasketProfile() 
        {
            CreateMap<CustomerBasket, BasketDtos>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}
