using Core.Contracts;

namespace Core.Entities {
    public class Collection : IEntity {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }

        public string ImagePath { get; set; }

        public IList<Product> Products { get; set; }
    }
}
