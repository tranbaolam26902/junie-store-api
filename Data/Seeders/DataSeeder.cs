using Core.Entities;
using Data.Contexts;

namespace Data.Seeders {
    public class DataSeeder : IDataSeeder {
        private readonly StoreDbContext _context;

        public DataSeeder(StoreDbContext context) {
            _context = context;
        }

        public void Initialize() {
            _context.Database.EnsureCreated();

            if (_context.Products.Any())
                return;

            var collections = AddCollections();
            var products = AddProducts(collections);
        }

        private IList<Collection> AddCollections() {
            var collections = new List<Collection>() {
                new() {
                    Title = "Bông Tai Nữ",
                    Description = "Bông tai là phụ kiện thời trang không thể thiếu của những cô nàng dễ thương. Hãy tô điểm cho bản thân với bộ sưu tập đa dạng những khuyên tai nữ cá tính của Junie.",
                    Slug = "earrings",
                    ImagePath = "/assets/images/collections/earrings/earrings.webp",
                },
                new() {
                    Title = "Dây Chuyền Nữ",
                    Description = "Chọn dây chuyền nàng yêu, làm những điều nàng thích",
                    Slug = "necklace",
                    ImagePath = "/assets/images/collections/necklace/necklace.webp"
                }
            };

            _context.AddRange(collections);
            _context.SaveChanges();

            return collections;
        }

        private IList<Product> AddProducts(IList<Collection> collections) {
            var products = new List<Product>() {
                new() {
                    Name = "Bông tai Jane",
                    Slug = "bong-tai-jane",
                    Price = 230000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-JANE-RG",
                    Ratings = 76,
                    Description = "Bông tai Jane đính ngọc trai nước ngọt, mang đến vẻ đẹp cao quý, trong sáng và thánh thiện. Sản phẩm được nhiều phái đẹp yêu thích là do nó vừa mang sự nhẹ nhàng, thanh nhã, nữ tính vừa mang nét mạnh mẽ, kiêu kỳ.\nBông tai Jane sẽ tôn vinh vẻ đẹp thân thiện, dịu dàng, từ đó dễ dàng lấy được thiện cảm từ những người xung quanh cho các cô gái.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-01.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-02.webp"
                        },
                    }
                }
            };

            _context.AddRange(products);
            _context.SaveChanges();

            return products;
        }
    }
}
