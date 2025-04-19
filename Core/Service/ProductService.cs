using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Service.Specifications;
using ServiceAbsrt;
using Shared;
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

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryparams)
        {
            var Specification = new ProductWithBrandWithType(queryparams);
            var Products = await unitOfWork.GetRepo<Product, int>().GetAllAsync(specification: Specification);
            var Data = mapper.Map<IEnumerable<ProductDto>>(Products);
            var ProductCount = Products.Count();
            return new PaginatedResult<ProductDto>(queryparams.PageIndex, ProductCount ,0,  Data);

        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Types = await unitOfWork.GetRepo<ProductType,int>().GetAllAsync();
            var TypesDto = mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return TypesDto;
        }

        public async Task<ProductDto> GetById(int Id)
        {
            var Specification = new ProductWithBrandWithType(Id);
            var Product = await unitOfWork.GetRepo<Product, int>().GetIdAsync(Specification);
            return mapper.Map<Product, ProductDto>(Product);
        }
       
    }
}
