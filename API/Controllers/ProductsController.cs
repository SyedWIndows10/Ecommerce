using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);

        }

        
        [HttpGet("brands/{id}")]

        public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id)
        {
            return await _repo.GetProductBrandByIdAsync(id);
        }

        
         [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var productbrands = await _repo.GetProductBrandsAsync();
            return Ok(productbrands);

        }

         
        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
        {
            return await _repo.GetProductTypeByIdAsync(id);
        }

        
         [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var producttypes = await _repo.GetProductTypesAsync();
            return Ok(producttypes);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }
    }
}