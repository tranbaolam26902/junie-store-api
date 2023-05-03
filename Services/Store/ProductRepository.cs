﻿using Core.Contracts;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;

namespace Services.Store {
    public class ProductRepository : IProductRepository {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context) {
            _context = context;
        }

        public async Task<IList<Product>> GetBestSellingProductsAsync(int limit, CancellationToken cancellationToken = default) {
            return await _context.Set<Product>()
                .Include(p => p.Collection)
                .Include(p => p.Images)
                .OrderByDescending(p => p.TotalSold)
                .Take(limit)
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<Product>> GetCollectionProductsBySlugAsync(string slug, CancellationToken cancellationToken = default) {
            return await _context.Set<Product>()
                .Include(p => p.Collection)
                .Include(p => p.Images)
                .Where(p => p.Collection.Slug == slug)
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<Product>> GetCollectionRandomProductsBySlugAsync(
            string slug,
            int limit,
            string currentProductSlug,
            CancellationToken cancellationToken = default) {
            return await _context.Set<Product>()
                .Include(p => p.Collection)
                .Include(p => p.Images)
                .Where(p => p.Collection.Slug == slug && p.Slug != currentProductSlug)
                .OrderBy(x => Guid.NewGuid())
                .Take(limit)
                .ToListAsync(cancellationToken);
        }

        public async Task<Product> GetProductBySlugAsync(string slug, CancellationToken cancellationToken = default) {
            return await _context.Set<Product>()
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Slug == slug, cancellationToken);
        }

        public async Task<IList<Product>> SearchProductAsync(string keyword, CancellationToken cancellationToken = default) {
            return await _context.Set<Product>()
                .Include(p => p.Images)
                .Include(p => p.Collection)
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
                .ToListAsync(cancellationToken);
        }

        public IQueryable<Product> FilterProduct(IProductQuery query) {
            IQueryable<Product> productQuery = _context.Set<Product>()
                .Include(p => p.Collection)
                .Include(p => p.Images.OrderBy(i => i.Id));

            if (!string.IsNullOrWhiteSpace(query.Keyword)) {
                productQuery = productQuery.Where(p => p.Name.ToLower().Contains(query.Keyword.ToLower()));
            }

            if (query.IsDiscounted) {
                productQuery = productQuery.Where(p => p.Discount > 0);
            }

            if (query.IsOutOfStock) {
                productQuery = productQuery.Where(p => p.Quantity == 0);
            }

            if (query.CollectionId != null && query.CollectionId != 0) {
                productQuery = productQuery.Where(p => p.Collection.Id == query.CollectionId);
            }

            return productQuery;
        }

        public async Task<IPagedList<T>> GetPagedProductsByQueriesAsync<T>(Func<IQueryable<Product>, IQueryable<T>> mapper, IProductQuery query, IPagingParams pagingParams, CancellationToken cancellationToken = default) {
            return await mapper(FilterProduct(query).AsNoTracking()).ToPagedListAsync(pagingParams, cancellationToken);
        }
    }
}
