using Ecommerce.Application.Products.DataTransfers.Responses;

namespace Ecommerce.Application.Carts.DataTransfers.Responses.Models
{
    public class CartProductResponse
    {
        public ProductResponse Product { get; set; }
        public int Quantity { get; set; }
    }
}
