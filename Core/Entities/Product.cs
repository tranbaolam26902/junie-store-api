using Core.Contracts;

namespace Core.Entities {
    public class Product : IEntity {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public double Price { get; set; }

        public float Discount { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }

        public int TotalSold { get; set; }

        public int? Ratings { get; set; }

        public string Description { get; set; }

        public string UserManual { get; set; }

        public bool? IsActive { get; set; }

        public int CollectionId { get; set; }

        public Collection Collection { get; set; }

        public IList<Image> Images { get; set; }

        public IList<OrderProducts> OrderProducts { get; set; }
    }
}
