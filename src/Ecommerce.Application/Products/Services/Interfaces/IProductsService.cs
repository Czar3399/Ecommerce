using Ecommerce.Application.Products.DataTransfers.Requests;
using Ecommerce.Application.Products.DataTransfers.Responses;

namespace Ecommerce.Application.Products.Services.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<ProductSimpleResponse> Query(ProductQueryRequest request);
    }
}