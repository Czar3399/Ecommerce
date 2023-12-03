namespace Ecommerce.Application.Products.DataTransfers.Requests
{
    public class ProductQueryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Trademark { get; set; }
    }
}
