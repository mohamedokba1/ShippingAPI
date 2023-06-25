using Microsoft.AspNetCore.Mvc;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductService _productService;

        //public ProductController(IProductService productService)
        //{
        //    _productService = productService;

        //}
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAllProduct()
        //{
        //    return Ok(await _productService.GetAllProductsAsync());

        //}
        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<ProductResponseDto>> GetProduct(long id)
        //{

        //    return Ok(await _productService.GetProductByIdAsync(id));
        //}

        //[HttpPut]
        //[Route("{id}")]
        //public async Task<ActionResult> updateProduct(long id, ProductUpdateDto product)
        //{
        //    try
        //    {
        //        await _productService.UpdateAsync(id, product);
        //        return NoContent();

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);

        //    }
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<ActionResult> DeleteProduct(long id)
        //{

        //    await _productService.DeleteAsync(id);
        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<ActionResult> AddProduct(ProductAddDto product)
        //{
        //    await _productService.AddAsync(product);
        //    return CreatedAtAction(nameof(GetProduct), new { id = product.Product_Id }, product);
        //}
    }
}
