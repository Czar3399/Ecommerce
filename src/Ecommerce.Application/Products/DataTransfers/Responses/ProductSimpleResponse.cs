namespace Ecommerce.Application.Products.DataTransfers.Responses
{
    public class ProductResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Trademark { get; set; }
        public decimal Price { get; set; }
    }
}
