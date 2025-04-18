using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransfetObject;

namespace Service.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dist=>dist.BrandName ,opt=>opt.MapFrom(src=>src.productBrand.Name))
                .ForMember(dist => dist.TypeName, opt => opt.MapFrom(src => src.productType.Name))
                .ForMember(dist => dist.PictureUrl, opt => opt.MapFrom(src =>$"https://localhost:7099/{src.pictureUrl }"));
            CreateMap<ProductType, TypeDto>();
            CreateMap<ProductBrand,BrandDto>();
        }
    }
}
