using Ecommerce.Application.Carts.DataTransfers.Requests;
using Ecommerce.Application.Carts.DataTransfers.Responses;

namespace Ecommerce.Application.Carts.Services.Interfaces
{
    public interface ICartsService
    {
        CartSimpleResponse AddCoupon(long id, string couponToken);
        CartSimpleResponse TryManipulateProducts(long id, CartProductRequest request);
        CartSimpleResponse Create();
        CartResponse Get(long id);
        CartSimpleResponse Submit(long cartId, IEnumerable<CartProductRequest> request);
    }
}