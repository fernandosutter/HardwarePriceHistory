using HardwarePriceHistory.Application.Services;
using HardwarePriceHistory.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HardwarePriceHistory.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductViewModel>> GetByName(string name)
        {
            var products = _productService.GetProducts(name);

            if(products.Count == 0)
                return NotFound();

            return Ok(products);
        }
    }
}
