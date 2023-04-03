using Core.Entities;

namespace Services.Store {
    public interface IProductRepository {
        /// <summary>
        /// Get collection's products by slug
        /// </summary>
        /// <param name="slug">Collection's slug</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of collection's Products</returns>
        Task<IList<Product>> GetCollectionProductsBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}
