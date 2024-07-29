using HardwarePriceHistory.Core.Models;

namespace HardwarePriceHistory.Application.ViewModel
{
    public class PriceHistoryViewModel
    {
        public decimal Price { get; init; }

        public DateTime Date { get; init; }

        public static PriceHistoryViewModel ToViewModel(PriceHistory priceHistory)
        {
            return new PriceHistoryViewModel
            {
                Price = priceHistory.Price,
                Date = priceHistory.Date
            };
        }
    }
}
