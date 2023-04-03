using Api.Models;
using Core.DTO;
using Core.Entities;
using MapsterMapper;
using Services.Store;

namespace Api.Endpoints {
    public static class ProductEndpoints {
        public static WebApplication MapProductEndpoints(this WebApplication app) {
            var routeGroupBuilder = app.MapGroup("/api/products");

            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}", GetProductsByCollectionSlug)
                .WithName("GetProductsByCollectionSlug")
                .Produces<ApiResponse<IList<Product>>>();

            return app;
        }

        private static async Task<IResult> GetProductsByCollectionSlug(
            string slug,
            IProductRepository productRepository,
            IMapper mapper) {
            return Results.Ok(ApiResponse.Success(mapper.Map<IList<ProductDTO>>(await productRepository.GetCollectionProductsBySlugAsync(slug))));
        }
    }
}
