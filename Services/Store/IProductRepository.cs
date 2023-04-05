using Core.Entities;

namespace Services.Store {
    public interface IProductRepository {
        /// <summary>
        /// Get best-selling Products
        /// </summary>
        /// <param name="limit">Number of Products</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of Products</returns>
        Task<IList<Product>> GetBestSellingProductsAsync(int limit, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Collection's products by slug
        /// </summary>
        /// <param name="slug">Collection's slug</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of Collection's Products</returns>
        Task<IList<Product>> GetCollectionProductsBySlugAsync(string slug, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Collection's random products by slug except current Product
        /// </summary>
        /// <param name="slug">Collection's slug</param>
        /// <param name="limit">Number of Products</param>
        /// <param name="currentProductSlug">Current Product's slug</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of random Product's</returns>
        Task<IList<Product>> GetCollectionRandomProductsBySlugAsync(
            string slug,
            int limit,
            string currentProductSlug,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Product by slug
        /// </summary>
        /// <param name="slug">Product's slug</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Product</returns>
        Task<Product> GetProductBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}
