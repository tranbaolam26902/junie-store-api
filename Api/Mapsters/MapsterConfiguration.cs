using Core.DTO;
using Core.Entities;
using Mapster;

namespace Api.Mapsters {
    public class MapsterConfiguration : IRegister {
        public void Register(TypeAdapterConfig config) {
            config.NewConfig<Collection, CollectionDTO>().Map(dest => dest.ProductsCount, src => src.Products == null ? 0 : src.Products.Count);
            config.NewConfig<Image, ImageDTO>();
            config.NewConfig<Product, ProductDTO>().Map(dest => dest.Images, src => src.Images.Take(2));
        }
    }
}
