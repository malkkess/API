using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfetObject;
using AutoMapper;

namespace ServiceAbsrt
{
    public interface IProductService
    {
        Task <IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetById(int Id);
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    }
}
