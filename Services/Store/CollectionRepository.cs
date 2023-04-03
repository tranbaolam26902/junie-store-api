using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Services.Store {
    public class CollectionRepository : ICollectionRepository {
        private readonly StoreDbContext _context;

        public CollectionRepository(StoreDbContext context) {
            _context = context;
        }

        public async Task<Collection> GetCollectionBySlugAsync(string slug, CancellationToken cancellationToken = default) {
            return await _context.Set<Collection>()
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Slug == slug, cancellationToken);
        }
    }
}
