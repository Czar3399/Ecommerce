using Ecommerce.Application.Carts.DataTransfers.Responses.Models;

namespace Ecommerce.Application.Carts.DataTransfers.Responses
{
    public class CartResponse : CartSimpleResponse
    {
        public IEnumerable<CartProductResponse> CartProducts { get; set; }
    }
}
