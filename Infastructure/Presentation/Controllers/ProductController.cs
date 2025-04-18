using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAbsrt;
using Shared.DataTransfetObject;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api[Controller]")]
    public class ProductController(IServiceManger servicemanger) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProucts()
        {
            var Products = await servicemanger.ProductService.GetAllProductsAsync();
            return Ok(Products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var Product = await servicemanger.ProductService.GetById(id);
            return Ok(Product);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetTypes()
        {
            var Types = await servicemanger.ProductService.GetAllTypesAsync();
            return Ok(Types);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
        {
            var Brands = await servicemanger.ProductService.GetAllBrandsAsync();
            return Ok(Brands);  
        }

    }
}
