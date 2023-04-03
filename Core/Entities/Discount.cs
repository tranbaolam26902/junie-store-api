using Core.Contracts;

namespace Core.Entities {
    public class Discount : IEntity {
        public int Id { get; set; }

        public string Code { get; set; }

        public float Value { get; set; }

        public double MinPrice { get; set; }

        public int? Quantity { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
