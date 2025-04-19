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
    public class ProductCountSpecification : BaseSpecifications<Product, int>
    {
        public ProductCountSpecification(ProductQueryParams queryParams) : base(p => (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId)
        && (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId) && (string.IsNullOrWhiteSpace(queryParams.SearchVlaue)
        || p.Name.ToLower().Contains(queryParams.SearchVlaue)))
        {
        }
    }
}
