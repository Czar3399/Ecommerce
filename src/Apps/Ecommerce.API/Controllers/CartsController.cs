using Ecommerce.Application.Carts.DataTransfers.Requests;
using Ecommerce.Application.Carts.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartsController(ICartsService cartsService) : ControllerBase
    {
        private readonly ICartsService _cartsService = cartsService;

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_cartsService.Get(id));
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok(_cartsService.Create());
        }

        [HttpPut("{id}/coupons")]
        public IActionResult AddCoupon(long id, [FromQuery] string coupon)
        {
            try
            {
                return Ok(_cartsService.AddCoupon(id, coupon));
            }
            catch (Exception)
            {
                return BadRequest("它沒有成功，去他媽的");
            }
        }

        [HttpPut("{id}/products")]
        public IActionResult AddProduct(long id, [FromBody] CartProductRequest request)
        {
            return Ok(_cartsService.TryManipulateProducts(id,request));
        }

        [HttpPut("{id}/submit")]
        public IActionResult Submit(long id, [FromBody] IEnumerable<CartProductRequest> request)
        {
            return Ok(_cartsService.Submit(id, request));
        }
    }
}
