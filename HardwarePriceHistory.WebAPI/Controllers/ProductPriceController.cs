using HardwarePriceHistory.Domain.Models;
using HardwarePriceHistory.Core.Services;
using HardwarePriceHistory.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HardwarePriceHistory.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        private readonly PriceHistoryService _priceHistoryService;
        
        public ProductPriceController(PriceHistoryService priceHistoryService)
        {
            _priceHistoryService = priceHistoryService;
        }


        [HttpGet]
        public ActionResult<List<PriceHistoryViewModel>> GetPriceHistory(long productBarCode, DateTime? initialDate, DateTime? finalDate)
        {
            var prices = _priceHistoryService.GetPrices(productBarCode, initialDate, finalDate);

            if(prices.Count == 0)
                return NotFound();

            return Ok(prices);
        }

    }
}
