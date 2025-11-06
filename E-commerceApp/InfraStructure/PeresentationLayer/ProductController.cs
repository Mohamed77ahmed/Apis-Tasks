using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PresentationLayer
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController(IServiceManager _serviceManager) : ControllerBase
    {
        //get all product
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllproductAsync([FromQuery]ProductQueryParams queryParams) 
        {
            var products= await _serviceManager.ProductService.GetAllProductAsync(queryParams);
            return Ok(products);

        }
        //get product by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var products = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(products);

        }
        //get all product brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllproductBransAsync()
        {
            var products = await _serviceManager.ProductService.GetAllProductBrandAsync();
            return Ok(products);

        }
        //get all product types
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllproductTypesAsync()
        {
            var products = await _serviceManager.ProductService.GetAllProductTypesAsync();
            return Ok(products);

        }



    }
}
