using Core.Contracts;

namespace Core.Entities {
    public class Order : IEntity {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string? AddressDescription { get; set; }

        public string Notes { get; set; }

        public double TotalPrice { get; set; }

        public Discount Discount { get; set; }

        public IList<OrderProducts> OrderProducts { get; set; }
    }
}
