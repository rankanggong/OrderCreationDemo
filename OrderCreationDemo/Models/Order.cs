namespace OrderCreationDemo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Items { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<Product> Items { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
