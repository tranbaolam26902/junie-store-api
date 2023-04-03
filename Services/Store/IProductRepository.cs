using Core.Entities;

namespace Services.Store {
    public interface IProductRepository {
        /// <summary>
        /// Get Collection's products by slug
        /// </summary>
        /// <param name="slug">Collection's slug</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of Collection's Products</returns>
        Task<IList<Product>> GetCollectionProductsBySlugAsync(string slug, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Product by slug
        /// </summary>
        /// <param name="slug">Product's slug</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Product</returns>
        Task<Product> GetProductBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}
