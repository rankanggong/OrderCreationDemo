using Microsoft.AspNetCore.Mvc;
using OrderCreationDemo.Models;
using System;
using System.Collections.Generic;
using OrderCreationDemo.Service;
using System.Threading.Tasks;
namespace OrderCreationDemo.Controllers
{

    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null || order.Items == null || order.Items.Count() == 0)
            {
                return BadRequest("Invalid order data.");
            }

            order.OrderId = Guid.NewGuid();
            order.CreatedAt = DateTime.UtcNow;
            var orderId  = await _orderService.CreateOrderAsync(new OrderDTO
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                CreatedAt = order.CreatedAt,
                Items = order.Items
            });

            return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
        }
    }
}