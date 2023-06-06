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
        private readonly IMapper _mapper;
        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDtos>> GetAllProduct()
        {
            var result = _mapper.Map<IEnumerable<ProductReadDtos>>(Product);
            return _productService.GetProductsAsync();

        }
    }
}
