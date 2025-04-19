using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace Service.Specifications
{
    class ProductWithBrandWithType : BaseSpecifications<Product, int>
    {
        public ProductWithBrandWithType(int? BrandId, int? TypeId) : base(p=>(!BrandId.HasValue || p.BrandId==BrandId)
        &&(!TypeId.HasValue || p.TypeId==TypeId))
        {
            AddInclude(p=>p.productBrand);
            AddInclude(p=>p.productType);
        }
        public ProductWithBrandWithType(int id) : base(p => p.Id == id)
        {

            AddInclude(p => p.productBrand);
            AddInclude(p => p.productType);
        }
    }
}
