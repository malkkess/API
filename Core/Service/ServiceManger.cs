using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbsrt;

namespace Service
{
    public class ServiceManger(IUnitOfWork unitOfWork , IMapper mapper , IBasketRepo basketRepo) : IServiceManger
    {
        private readonly Lazy<IProductService> LazyProductService = new Lazy<IProductService>(()=>new ProductService(unitOfWork , mapper));
        public IProductService ProductService => LazyProductService.Value;

        private readonly Lazy<IBasketService> _LazyBasketService = new Lazy<IBasketService>(() => new BasketService(basketRepo, mapper));
        public IBasketService BasketService => _LazyBasketService.Value;
    }
}
