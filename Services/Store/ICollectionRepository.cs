using Core.Entities;

namespace Services.Store {
    public interface ICollectionRepository {
        /// <summary>
        /// Get a Collection by slug
        /// </summary>
        /// <param name="slug">Collection's slug</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Collection</returns>
        Task<Collection> GetCollectionBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}
