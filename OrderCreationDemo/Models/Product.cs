namespace OrderCreationDemo.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductDTO
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
