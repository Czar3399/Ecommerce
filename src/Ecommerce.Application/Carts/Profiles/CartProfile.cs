using AutoMapper;
using Ecommerce.Application.Carts.DataTransfers.Responses;
using Ecommerce.Domain.Carts.Entities;

namespace Ecommerce.Application.Products.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartSimpleResponse>();
            CreateMap<Cart, CartResponse>();
        }
    }
}
