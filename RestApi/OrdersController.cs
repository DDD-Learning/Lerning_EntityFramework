using Application;
using Domain.Model.Orders;
using Microsoft.AspNetCore.Mvc;

namespace RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _orderService.GetOrderAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto viewModel)
        {
            var result = await _orderService.PlaceOrderAsync(viewModel);

            return Ok(result);
        }

        [HttpPut("/{id}/Archive")]
        public async Task<IActionResult> Archive(long id)
        {
            await _orderService.ArchiveAsync(id);

            return Ok();
        }
    }
}