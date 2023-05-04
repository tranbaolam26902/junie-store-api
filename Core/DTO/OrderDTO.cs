namespace Core.DTO {
    public class OrderDTO {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string? AddressDescription { get; set; }

        public string? Notes { get; set; }

        public double TotalPrice { get; set; }

        public bool IsFreeDelivery { get; set; }

        public bool IsConfirmed { get; set; }

        public IList<OrderProductsDTO> OrderProducts { get; set; }
    }
}
