using AutoMapper;
using Ecommerce.Application.Carts.DataTransfers.Responses;
using Ecommerce.Application.Carts.DataTransfers.Responses.Models;
using Ecommerce.Domain.CartProducts.Entities;
using Ecommerce.Domain.Carts.Entities;

namespace Ecommerce.Application.Products.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartSimpleResponse>();
            CreateMap<Cart, CartResponse>();
            CreateMap<CartProduct, CartProductResponse>();
        }
    }
}
