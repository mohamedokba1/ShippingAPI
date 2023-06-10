using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Entities.Domain.Models;
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
        public ActionResult<IEnumerable<ProductReadDtos>> GetAllProduct()
        {
            var result = _productService.GetProductsAsync();

            return result;

        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductReadDtos> GetProduct(Guid id)
        {
            return _productService.GetProductByIdAsync(id);
        }
    }
}
