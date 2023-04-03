using Api.Models;
using Core.Entities;
using MapsterMapper;
using Services.Store;
using System.Net;

namespace Api.Endpoints {
    public static class CollectionEndpoints {
        public static WebApplication MapCollectionEndpoints(this WebApplication app) {
            var routeGroupBuilder = app.MapGroup("/api/collections");

            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}", GetCollectionBySlug)
                .WithName("GetCollectionBySlug")
                .Produces<ApiResponse<Collection>>();

            return app;
        }

        private static async Task<IResult> GetCollectionBySlug(
            string slug,
            ICollectionRepository collectionRepository,
            IMapper mapper) {
            var collection = await collectionRepository.GetCollectionBySlugAsync(slug);

            return collection != null
                ? Results.Ok(ApiResponse.Success(collection))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Không tìm thấy bộ sưu tập!"));
        }
    }
}
