using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbsrt;
using Shared.DataTransfetObject;

namespace Service
{
    public class ProductService(IUnitOfWork unitOfWork,IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var Repo = unitOfWork.GetRepo<ProductBrand, int>();
            var Brands = await Repo.GetAllAsync();
            var BrandDto= mapper.Map<IEnumerable<ProductBrand>,IEnumerable<BrandDto>>(Brands);
            return BrandDto;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var Products = await unitOfWork.GetRepo<Product, int>().GetAllAsync();
            return mapper.Map<IEnumerable<ProductDto>>(Products);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Types = await unitOfWork.GetRepo<ProductType,int>().GetAllAsync();
            var TypesDto = mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return TypesDto;
        }

        public async Task<ProductDto> GetById(int Id)
        {
            var Product = await unitOfWork.GetRepo<Product, int>().GetIdAsync(Id);
            return mapper.Map<Product, ProductDto>(Product);
        }
    }
}
