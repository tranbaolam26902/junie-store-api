namespace Api.Models {
    public class OrderFilterModel : PagingModel {
        public string Keyword { get; set; } = "";

        public bool? IsNotConfirmed { get; set; } = false;
    }
}
