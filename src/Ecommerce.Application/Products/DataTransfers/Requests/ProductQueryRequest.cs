namespace Ecommerce.Application.Products.DataTransfers.Requests
{
    public class ProductQueryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Trademark { get; set; }
    }
}
