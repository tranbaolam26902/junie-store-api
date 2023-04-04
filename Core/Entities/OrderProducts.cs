namespace Core.Entities {
    public class OrderProducts {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
