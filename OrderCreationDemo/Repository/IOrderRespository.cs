using System.Threading.Tasks;
using OrderCreationDemo.Models;

public interface IOrderRepository
{
    public Task<Order> AddOrderAsync(Order order);
}