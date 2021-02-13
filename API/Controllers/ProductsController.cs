using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        
        {
            _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            //var products = await _repo.GetProductsAsync();
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var products = await _productsRepo.ListAsync(spec);
            //return Ok(products);
           //  if (products == null) return NotFound(new ApiResponse(404));

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

             return Ok(data);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            
            var data = _mapper.Map<Product, ProductToReturnDto>(product);

             return Ok(data);
        }

        [HttpGet("brands/{id}")]

        public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id)
        {
            return await _productBrandRepo.GetByIdAsync(id);
        }

        
         [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var productbrands = await _productBrandRepo.ListAllAsync();
            return Ok(productbrands);

        }

         
        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
        {
            return await _productTypeRepo.GetByIdAsync(id);
        }

        
         [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var producttypes = await _productTypeRepo.ListAllAsync();
            return Ok(producttypes);

        }

       
    }
}