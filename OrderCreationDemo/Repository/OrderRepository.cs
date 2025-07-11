using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderCreationDemo.Models;

namespace OrderCreationDemo.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public Task<Order> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}