using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Services.Store {
    public class ProductRepository : IProductRepository {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context) {
            _context = context;
        }

        public async Task<IList<Product>> GetCollectionProductsBySlugAsync(string slug, CancellationToken cancellationToken = default) {
            return await _context.Set<Product>()
                .Include(p => p.Images)
                .Where(p => p.Collection.Slug == slug)
                .ToListAsync(cancellationToken);
        }

        public async Task<Product> GetProductBySlugAsync(string slug, CancellationToken cancellationToken = default) {
            return await _context.Set<Product>()
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Slug == slug, cancellationToken);
        }
    }
}
