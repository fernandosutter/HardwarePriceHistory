using HardwarePriceHistory.Data.Interfaces;
using HardwarePriceHistory.Models;
using HardwarePriceHistory.WebAPI.Services;
using Microsoft.AspNetCore.Http;
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
        public List<PriceHistory> GetPriceHistory(int productId, DateTime? initialDate, DateTime? finalDate)
        {
            var prices = _priceHistoryService.GetPrices(productId, initialDate, finalDate);

            return prices;
        }

    }
}
