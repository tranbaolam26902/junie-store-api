using Api.Models;
using Core.DTO;
using MapsterMapper;
using Services.Store;

namespace Api.Endpoints {
    public static class ProductEndpoints {
        public static WebApplication MapProductEndpoints(this WebApplication app) {
            var routeGroupBuilder = app.MapGroup("/api/products");

            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}", GetProductBySlug)
                .WithName("GetProductBySlug")
                .Produces<ApiResponse<ProductDetailDTO>>();

            return app;
        }

        private static async Task<IResult> GetProductBySlug(
            string slug,
            IProductRepository productRepository,
            IMapper mapper) {
            return Results.Ok(ApiResponse.Success(mapper.Map<ProductDetailDTO>(await productRepository.GetProductBySlugAsync(slug))));
        }
    }
}
