namespace Core.DTO {
    public class ProductDTO {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public double Price { get; set; }

        public float Discount { get; set; }

        public int Quantity { get; set; }

        public CollectionDTO Collection { get; set; }

        public IList<ImageDTO> Images { get; set; }
    }
}
