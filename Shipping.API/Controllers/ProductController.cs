using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.ProductDtos;
using Shipping.Services.IServices;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
            
        }
        [HttpGet]
        public async Task< ActionResult<IEnumerable<ProductReadDtos>> >GetAllProduct()
        {
            return Ok( await _productService.GetProductsAsync());

        }
        [HttpGet]
        [Route("{id}")]
        public async Task< ActionResult<ProductReadDtos>> GetProduct(Guid id)
        {
            
            return Ok(await _productService.GetProductByIdAsync(id));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> updateProduct(Guid id , ProductUpdateDtos product)
        {
            

                try
                {
                    await _productService.UpdateAsync(id, product);
                    return NoContent();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }
            
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
        
            await _productService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(AddProductDto product)
        {
            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new {id=product.Product_Id}, product);
        }
    }
}
