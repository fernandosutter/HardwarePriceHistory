namespace HardwarePriceHistory.Core.Models
{
    public class PriceHistory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}