using Core.Contracts;

namespace Services.Queries {
    public class OrderQuery : IOrderQuery {
        public string Keyword { get; set; }
        public bool IsNotConfirmed { get; set; }
    }
}
