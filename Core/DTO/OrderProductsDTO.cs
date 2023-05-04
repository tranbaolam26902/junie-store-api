namespace Core.DTO {
    public class OrderProductsDTO {
        public string ProductName { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double TotalPrice {
            get {
                return (double)Price * Quantity;
            }
        }
    }
}
