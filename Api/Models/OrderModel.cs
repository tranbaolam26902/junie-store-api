namespace Api.Models {
    public class OrderModel {
        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string? AddressDescription { get; set; }

        public string? Notes { get; set; }

        public IList<OrderProductsModel> OrderProducts { get; set; }

        public OrderModel() {
            OrderProducts = new List<OrderProductsModel>();
        }
    }
}
