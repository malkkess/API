using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using Shared;

namespace Service.Specifications
{
    class ProductWithBrandWithType : BaseSpecifications<Product, int>
    {
        public ProductWithBrandWithType(ProductQueryParams queryParams) : base(p=>(!queryParams.BrandId.HasValue || p.BrandId== queryParams.BrandId)
        &&(!queryParams.TypeId.HasValue || p.TypeId== queryParams.TypeId)&& (string.IsNullOrWhiteSpace(queryParams.SearchVlaue) || p.Name.ToLower().Contains(queryParams.SearchVlaue)))
        {
            AddInclude(p=>p.productBrand);
            AddInclude(p=>p.productType);
            switch (queryParams.SortingOptions) 
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p=>p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p=>p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p=>p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p=>p.Price);
                    break;
                
            }
            ApplyPagination(queryParams.PageSize , queryParams.PageIndex);
        }
        public ProductWithBrandWithType(int id) : base(p => p.Id == id)
        {

            AddInclude(p => p.productBrand);
            AddInclude(p => p.productType);
        }
    }
}
