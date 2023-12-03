namespace Ecommerce.Application.Carts.DataTransfers.Responses.Models
{
    public class CartProductResponse
    {
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int ProductImage { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
