using Core.Contracts;

namespace Services.Queries {
    public class ProductQuery : IProductQuery {
        public string Keyword { get; set; }

        public bool IsDiscounted { get; set; }

        public bool IsOutOfStock { get; set; }

        public int? CollectionId { get; set; }
    }
}
