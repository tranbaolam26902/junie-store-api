using Api.Models;
using Core.DTO;
using Core.Entities;
using Mapster;
using Services.Queries;

namespace Api.Mapsters {
    public class MapsterConfiguration : IRegister {
        public void Register(TypeAdapterConfig config) {
            config.NewConfig<Collection, CollectionDTO>().Map(dest => dest.ProductsCount, src => src.Products == null ? 0 : src.Products.Count);
            config.NewConfig<Image, ImageDTO>();
            config.NewConfig<Product, ProductDTO>();
            config.NewConfig<Product, ProductDTO>().Map(dest => dest.Images, src => src.Images.Take(2));
            config.NewConfig<Product, ProductDetailDTO>();
            config.NewConfig<ProductEditModel, Product>();
            config.NewConfig<ProductFilterModel, ProductQuery>();
            config.NewConfig<Order, OrderModel>();
            config.NewConfig<Order, OrderDTO>();
            config.NewConfig<OrderProducts, OrderProductsModel>();
            config.NewConfig<OrderProducts, OrderProductsDTO>().Map(dest => dest.ProductName, src => src.Product.Name);
            config.NewConfig<OrderProducts, OrderProductsDTO>().Map(dest => dest.ImageUrl, src => src.Product.Images[0].Path);
        }
    }
}
