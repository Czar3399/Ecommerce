using AutoMapper;
using Ecommerce.Application.Products.DataTransfers.Responses;
using Ecommerce.Domain.Products.Entities;

namespace Ecommerce.Application.Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductSimpleResponse>();
        }
    }
}
