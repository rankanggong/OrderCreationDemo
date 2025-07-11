using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrderCreationDemo.Models;
using OrderCreationDemo.Repository;

namespace OrderCreationDemo.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Guid> CreateOrderAsync(OrderDTO orderDto)
        {
            try
            {
                var order = new Order
                {
                    OrderId = orderDto.OrderId,
                    CustomerName = orderDto.CustomerName,
                    CreatedAt = orderDto.CreatedAt,
                    Items = orderDto.Items.Select(i => new Product
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity
                    }).ToList()
                };

                await _orderRepository.AddOrderAsync(order);
                _logger.LogInformation("Order created successfully with ID: {OrderId}", order.OrderId);

                return order.OrderId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                throw;
            }
        }
    }
}