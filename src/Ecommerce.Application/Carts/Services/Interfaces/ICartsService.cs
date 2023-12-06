using Ecommerce.Application.Carts.DataTransfers.Requests;
using Ecommerce.Application.Carts.DataTransfers.Responses;
using Ecommerce.Application.Carts.DataTransfers.Responses.Models;

namespace Ecommerce.Application.Carts.Services.Interfaces
{
    public interface ICartsService
    {
        CartResponse AddCoupon(long id, string couponToken);
        CartResponse TryManipulateProducts(long id, CartProductRequest request);
        CartResponse Create();
        CartResponse Get(long id);
        CartResponse Submit(long cartId, IEnumerable<CartProductRequest> request);
    }
}