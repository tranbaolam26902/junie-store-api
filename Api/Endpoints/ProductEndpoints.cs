using Api.Models;
using Core.Collections;
using Core.DTO;
using Mapster;
using MapsterMapper;
using Services.Queries;
using Services.Store;

namespace Api.Endpoints {
    public static class ProductEndpoints {
        public static WebApplication MapProductEndpoints(this WebApplication app) {
            var routeGroupBuilder = app.MapGroup("/api/products");

            routeGroupBuilder.MapGet("/best-selling/{limit:int}", GetBestSellingProducts)
                .WithName("GetBestSellingProducts")
                .Produces<ApiResponse<IList<ProductDTO>>>();

            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}", GetProductBySlug)
                .WithName("GetProductBySlug")
                .Produces<ApiResponse<ProductDetailDTO>>();

            routeGroupBuilder.MapGet("/random/{slug:regex(^[a-z0-9_-]+$)}/{limit:int}/{currentProductSlug:regex(^[a-z0-9_-]+$)}", GetCollectionRandomProductsBySlug)
                .WithName("GetCollectionRandomProductsBySlug")
                .Produces<ApiResponse<IList<ProductDTO>>>();

            routeGroupBuilder.MapPost("/search", SearchProduct)
                .WithName("SearchProduct")
                .Produces<ApiResponse<IList<ProductDTO>>>();

            routeGroupBuilder.MapGet("/", GetProductsByQueries)
                .WithName("GetProductsByQueries")
                .Produces<ApiResponse<PaginationResult<ProductDTO>>>();

            return app;
        }

        private static async Task<IResult> GetBestSellingProducts(
            int limit,
            IProductRepository productRepository,
            IMapper mapper) {
            return Results.Ok(ApiResponse.Success(mapper.Map<IList<ProductDTO>>(await productRepository.GetBestSellingProductsAsync(limit))));
        }

        private static async Task<IResult> GetProductBySlug(
            string slug,
            IProductRepository productRepository,
            IMapper mapper) {
            return Results.Ok(ApiResponse.Success(mapper.Map<ProductDetailDTO>(await productRepository.GetProductBySlugAsync(slug))));
        }

        private static async Task<IResult> GetCollectionRandomProductsBySlug(
            string slug,
            int limit,
            string currentProductSlug,
            IProductRepository productRepository,
            IMapper mapper) {
            return Results.Ok(ApiResponse.Success(mapper.Map<IList<ProductDTO>>(await productRepository.GetCollectionRandomProductsBySlugAsync(slug, limit, currentProductSlug))));
        }

        private static async Task<IResult> SearchProduct(
            SearchModel model,
            IProductRepository productRepository,
            IMapper mapper) {
            return Results.Ok(ApiResponse.Success(mapper.Map<IList<ProductDTO>>(await productRepository.SearchProductAsync(model.Keyword))));
        }

        private static async Task<IResult> GetProductsByQueries(
            [AsParameters] ProductFilterModel model,
            IMapper mapper,
            IProductRepository productRepository) {
            var query = mapper.Map<ProductQuery>(model);
            var products = await productRepository.GetPagedProductsByQueriesAsync(p => p.ProjectToType<ProductDTO>(), query, model);
            var paginationResult = new PaginationResult<ProductDTO>(products);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }
    }
}
