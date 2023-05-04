using Core.Contracts;
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

        /// <summary>
        /// Search Product by Keyword
        /// </summary>
        /// <param name="keyword">Search keyword</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IList<Product>> SearchProductAsync(string keyword, CancellationToken cancellationToken = default);

        /// <summary>
        /// Filter Products by queries
        /// </summary>
        /// <param name="query">Product queries</param>
        /// <returns></returns>
        IQueryable<Product> FilterProduct(IProductQuery query);

        /// <summary>
        /// Paginate products filtered by queries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mapper"></param>
        /// <param name="query"></param>
        /// <param name="pagingParams"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IPagedList<T>> GetPagedProductsByQueriesAsync<T>(Func<IQueryable<Product>, IQueryable<T>> mapper, IProductQuery query, IPagingParams pagingParams, CancellationToken cancellationToken = default);

        /// <summary>
        /// Check whether slug existed or not
        /// </summary>
        /// <param name="id">Excluded product's id</param>
        /// <param name="slug">Slug need to be checked</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<bool> IsSlugExistedAsync(int id, string slug, CancellationToken cancellation = default);

        /// <summary>
        /// Create a new product or update if existed
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task CreateOrUpdateProductAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Product's images by id
        /// </summary>
        /// <param name="id">Product's id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IList<Image>> GetProductImagesByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete Product's images by id
        /// </summary>
        /// <param name="id">Product's id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteProductImagesByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add image to Product
        /// </summary>
        /// <param name="id">Product's id</param>
        /// <param name="imageUrl">Image URL</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> AddImageToProductAsync(int id, string imageUrl, CancellationToken cancellationToken = default);

        /// <summary>
        ///  Delete Product by slug
        /// </summary>
        /// <param name="slug">Product's slug</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteProductBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}
