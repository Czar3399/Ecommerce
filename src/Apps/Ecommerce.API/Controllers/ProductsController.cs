using Ecommerce.Application.Products.DataTransfers.Requests;
using Ecommerce.Application.Products.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(IProductsService productsService) : ControllerBase
    {
        private readonly IProductsService _productsService = productsService;

        [HttpGet]
        public IActionResult Query([FromQuery] ProductQueryRequest request)
        {
            return Ok(_productsService.Query(request));
        }
    }
}
