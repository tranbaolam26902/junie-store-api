namespace Core.DTO {
    public class ProductDetailDTO {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public float Discount { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }

        public int? Ratings { get; set; }

        public string Description { get; set; }

        public string UserManual { get; set; }

        public int CollectionId { get; set; }

        public IList<ImageDTO> Images { get; set; }
    }
}
