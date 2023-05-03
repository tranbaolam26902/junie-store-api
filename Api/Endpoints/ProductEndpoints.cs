using Api.Models;
using Core.Collections;
using Core.DTO;
using Core.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Media;
using Services.Queries;
using Services.Store;
using System.Net;

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

            routeGroupBuilder.MapPost("/", CreateProduct)
                .WithName("CreateProduct")
                .Produces<ApiResponse<string>>();

            routeGroupBuilder.MapPost("/{slug:regex(^[a-z0-9_-]+$)}/images", SetProductImages)
                .WithName("SetProductImages")
                .Accepts<IList<IFormFile>>("multipart/form-data")
                .Produces<ApiResponse<string>>();

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

        private static async Task<IResult> CreateProduct(
            ProductEditModel model,
            IMapper mapper,
            IProductRepository productRepository) {
            if (await productRepository.IsSlugExistedAsync(0, model.Slug)) {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict,
                    $"Slug {model.Slug} existed!"));
            }

            var product = mapper.Map<Product>(model);

            product.Id = 0;

            await productRepository.CreateOrUpdateProductAsync(product);
            return Results.Ok(ApiResponse.Success("Success!"));
        }

        private static async Task<IResult> SetProductImages(
        [FromRoute] string slug,
        HttpContext context,
        IProductRepository productRepository,
        IMediaManager mediaManager) {
            var files = context.Request.Form.Files;
            var product = await productRepository.GetProductBySlugAsync(slug);
            if (product == null) {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.NotFound,
                    $"Not found product with slug '{slug}'"));
            }

            var images = await productRepository.GetProductImagesByIdAsync(product.Id);

            foreach (var image in images) {
                await mediaManager.DeleteFileAsync(image.Path);
            }

            await productRepository.DeleteProductImagesByIdAsync(product.Id);

            foreach (var file in files) {
                var imageUrl = await mediaManager.SaveFileAsync(
                    file.OpenReadStream(),
                    file.FileName, file.ContentType);

                if (string.IsNullOrWhiteSpace(imageUrl)) {
                    return Results.Ok(ApiResponse.Fail(
                        HttpStatusCode.BadRequest,
                        "Không lưu được tệp"));
                }

                await productRepository.AddImageToProductAsync(product.Id, imageUrl);
            }

            return Results.Ok(ApiResponse.Success("Lưu thành công"));
        }
    }
}
