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
            config.NewConfig<Product, ProductDTO>().Map(dest => dest.Images, src => src.Images.Take(2));
            config.NewConfig<Product, ProductDetailDTO>();
            config.NewConfig<ProductFilterModel, ProductQuery>();
            config.NewConfig<Order, OrderModel>();
            config.NewConfig<OrderProducts, OrderProductsModel>();
        }
    }
}
