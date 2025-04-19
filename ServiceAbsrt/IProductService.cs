using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfetObject;
using AutoMapper;
using Shared;

namespace ServiceAbsrt
{
    public interface IProductService
    {
        Task <IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams);
        Task<ProductDto> GetById(int Id);
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    }
}
