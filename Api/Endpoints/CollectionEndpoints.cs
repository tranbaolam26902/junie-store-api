using Api.Models;
using Core.DTO;
using Core.Entities;
using MapsterMapper;
using Services.Store;
using System.Net;

namespace Api.Endpoints {
    public static class CollectionEndpoints {
        public static WebApplication MapCollectionEndpoints(this WebApplication app) {
            var routeGroupBuilder = app.MapGroup("/api/collections");

            routeGroupBuilder.MapGet("/", GetCollections)
                .WithName("GetCollections")
                .Produces<ApiResponse<IList<CollectionDTO>>>();

            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}", GetCollectionBySlug)
                .WithName("GetCollectionBySlug")
                .Produces<ApiResponse<CollectionDTO>>();

            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}/products", GetProductsByCollectionSlug)
                .WithName("GetProductsByCollectionSlug")
                .Produces<ApiResponse<IList<Product>>>();

            return app;
        }

        private static async Task<IResult> GetCollections(
            ICollectionRepository collectionRepository,
            IMapper mapper) {
            return Results.Ok(ApiResponse.Success(mapper.Map<IList<CollectionDTO>>(await collectionRepository.GetCollectionsAsync())));
        }

        private static async Task<IResult> GetCollectionBySlug(
            string slug,
            ICollectionRepository collectionRepository,
            IMapper mapper) {
            var collection = await collectionRepository.GetCollectionBySlugAsync(slug);

            return collection != null
                ? Results.Ok(ApiResponse.Success(mapper.Map<CollectionDTO>(collection)))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Không tìm thấy bộ sưu tập!"));
        }

        private static async Task<IResult> GetProductsByCollectionSlug(
            string slug,
            IProductRepository productRepository,
            IMapper mapper) {
            return Results.Ok(ApiResponse.Success(mapper.Map<IList<ProductDTO>>(await productRepository.GetCollectionProductsBySlugAsync(slug))));
        }
    }
}
