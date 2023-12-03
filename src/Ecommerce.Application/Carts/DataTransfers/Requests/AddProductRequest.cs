namespace Ecommerce.Application.Carts.DataTransfers.Requests
{
    public class CartProductRequest
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
