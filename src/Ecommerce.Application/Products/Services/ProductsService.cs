using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Products.DataTransfers.Requests;
using Ecommerce.Application.Products.DataTransfers.Responses;
using Ecommerce.Application.Products.Services.Interfaces;
using Ecommerce.Domain.Products.Entities;
using Linq.Fluent.Expressions;
using Vault.Base.Repositories;

namespace Ecommerce.Application.Products.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public ProductsService(IQueryRepository queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductResponse> Query(ProductQueryRequest request)
        {
            var query = _queryRepository.Query<Product>();

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.WhereParam(x => x.Name).Like(request.Name);
            }
            if (!string.IsNullOrEmpty(request.Description))
            {
                query = query.WhereParam(x => x.Description).Like(request.Description);
            }
            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query.WhereParam(x => x.Category).Like(request.Category);
            }
            if (!string.IsNullOrEmpty(request.Trademark))
            {
                query = query.WhereParam(x => x.Trademark).Like(request.Trademark);
            }
            if (request.MaxPrice.HasValue)
            {
                query = query.WhereParam(x => x.Price).IsSmallerThen(request.MaxPrice.Value);
            }
            if (request.MinPrice.HasValue)
            {
                query = query.WhereParam(x => x.Price).IsBiggerThen(request.MinPrice.Value);
            }
            return query.ProjectTo<ProductResponse>(_mapper.ConfigurationProvider);
        }
    }
}
