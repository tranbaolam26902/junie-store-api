namespace Api.Models {
    public class ProductEditModel {
        public string Name { get; set; }

        public string Slug { get; set; }

        public double Price { get; set; }

        public float Discount { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string UserManual { get; set; }

        public int CollectionId { get; set; }
    }
}
