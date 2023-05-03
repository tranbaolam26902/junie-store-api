namespace Api.Models {
    public class ProductFilterModel : PagingModel {
        public string Keyword { get; set; } = "";

        public bool? IsDiscounted { get; set; } = false;

        public bool? IsOutOfStock { get; set; } = false;

        public int? CollectionId { get; set; } = 0;
    }
}
