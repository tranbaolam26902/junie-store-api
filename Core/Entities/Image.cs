using Core.Contracts;

namespace Core.Entities {
    public class Image : IEntity {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Path { get; set; }

        public Product Product { get; set; }
    }
}
