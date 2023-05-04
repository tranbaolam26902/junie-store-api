using Api.Models;
using Core.Collections;
using Core.DTO;
using Core.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                .Accepts<IList<IFormFile>>("multipart/form-data")
                .Produces<ApiResponse<string>>();

            routeGroupBuilder.MapPost("/update", UpdateProduct)
                .WithName("UpdateProduct")
                .Accepts<IList<IFormFile>>("multipart/form-data")
                .Produces<ApiResponse<string>>();

            routeGroupBuilder.MapPost("/delete/{slug:regex(^[a-z0-9_-]+$)}", DeleteProductBySlug)
                .WithName("DeleteProductBySlug")
                .Produces<ApiResponse<bool>>();

            //routeGroupBuilder.MapPost("/{slug:regex(^[a-z0-9_-]+$)}/images", SetProductImages)
            //    .WithName("SetProductImages")
            //    .Accepts<IList<IFormFile>>("multipart/form-data")
            //    .Produces<ApiResponse<string>>();

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
            HttpContext httpContext,
            IMediaManager mediaManager,
            IProductRepository productRepository) {
            var productData = httpContext.Request.Form["model"];
            var files = httpContext.Request.Form.Files;
            var product = JsonConvert.DeserializeObject<Product>(productData);

            product.Id = 0;

            if (await productRepository.IsSlugExistedAsync(product.Id, product.Slug))
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug {product.Slug} existed!"));

            await productRepository.CreateOrUpdateProductAsync(product);

            var newProduct = await productRepository.GetProductBySlugAsync(product.Slug);

            newProduct.Images = new List<Image>();
            foreach (var file in files) {
                var imageUrl = await mediaManager.SaveFileAsync(file.OpenReadStream(), file.FileName, file.ContentType);

                if (string.IsNullOrWhiteSpace(imageUrl))
                    return Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, "Cannot save file!"));

                newProduct.Images.Add(new Image() {
                    ProductId = newProduct.Id,
                    Path = imageUrl
                });
            }

            await productRepository.CreateOrUpdateProductAsync(newProduct);

            return Results.Ok(ApiResponse.Success("Success!"));
        }

        private static async Task<IResult> UpdateProduct(
            HttpContext httpContext,
            IMediaManager mediaManager,
            IProductRepository productRepository) {
            var productData = httpContext.Request.Form["model"];
            var files = httpContext.Request.Form.Files;
            var product = JsonConvert.DeserializeObject<Product>(productData);
            var existedProduct = await productRepository.GetProductBySlugAsync(product.Slug);
            var images = await productRepository.GetProductImagesByIdAsync(existedProduct.Id);

            existedProduct.Name = product.Name;
            existedProduct.Price = product.Price;
            existedProduct.Discount = product.Discount;
            existedProduct.Quantity = product.Quantity;
            existedProduct.Type = product.Type;
            existedProduct.Description = product.Description;
            existedProduct.UserManual = product.UserManual;

            foreach (var image in images)
                await mediaManager.DeleteFileAsync(image.Path);
            await productRepository.DeleteProductImagesByIdAsync(existedProduct.Id);

            foreach (var file in files) {
                var imageUrl = await mediaManager.SaveFileAsync(file.OpenReadStream(), file.FileName, file.ContentType);

                if (string.IsNullOrWhiteSpace(imageUrl))
                    return Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, "Cannot save file!"));

                await productRepository.AddImageToProductAsync(existedProduct.Id, imageUrl);
            }

            await productRepository.CreateOrUpdateProductAsync(existedProduct);

            return Results.Ok(ApiResponse.Success("Success!"));
        }

        private static async Task<IResult> DeleteProductBySlug(
            [FromRoute] string slug,
            IProductRepository productRepository) {
            return Results.Ok(ApiResponse.Success(await productRepository.DeleteProductBySlugAsync(slug)));
        }

        //private static async Task<IResult> SetProductImages(
        //[FromRoute] string slug,
        //HttpContext context,
        //IProductRepository productRepository,
        //IMediaManager mediaManager) {
        //    var files = context.Request.Form.Files;
        //    var product = await productRepository.GetProductBySlugAsync(slug);
        //    if (product == null) {
        //        return Results.Ok(ApiResponse.Fail(
        //            HttpStatusCode.NotFound,
        //            $"Not found product with slug '{slug}'"));
        //    }

        //    var images = await productRepository.GetProductImagesByIdAsync(product.Id);

        //    foreach (var image in images) {
        //        await mediaManager.DeleteFileAsync(image.Path);
        //    }

        //    await productRepository.DeleteProductImagesByIdAsync(product.Id);

        //    foreach (var file in files) {
        //        var imageUrl = await mediaManager.SaveFileAsync(
        //            file.OpenReadStream(),
        //            file.FileName, file.ContentType);

        //        if (string.IsNullOrWhiteSpace(imageUrl)) {
        //            return Results.Ok(ApiResponse.Fail(
        //                HttpStatusCode.BadRequest,
        //                "Không lưu được tệp"));
        //        }

        //        await productRepository.AddImageToProductAsync(product.Id, imageUrl);
        //    }

        //    return Results.Ok(ApiResponse.Success("Lưu thành công"));
        //}
    }
}
