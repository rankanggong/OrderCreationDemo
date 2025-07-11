using OrderCreationDemo.Models;

namespace OrderCreationDemo.Service
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(OrderDTO order);
    }
}