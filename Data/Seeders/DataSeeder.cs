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
            var discounts = AddDiscounts();
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
                },
                new() {
                    Name = "Bông tai Lumi",
                    Slug = "bong-tai-lumi",
                    Price = 195000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-LUMI-RG",
                    Description = "Thêm chút phong cách trang nhã cho đôi tai của bạn với đôi bông tai ôm sát đầy tinh tế của Junie.\nBông taI Lumi được chế tác tỉ mỉ từ bạc 925 cao cấp, phủ một lớp dày vàng 14K, kết hợp với đá Cubic Zirconia lấp lánh tạo nên một thiết kế hoàn mỹ, là điểm nhấn duyên dáng trên vành tai nhỏ xinh của nàng.\nThiết kế đơn giản, nhưng không kém phần tinh tế để nàng có thể kết hợp cùng nhiều loại trang phục trong các dịp khác nhau như đi làm, đi chơi, thậm chí cả những bữa tiệc nhẹ nhàng.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 2,
                            Path = "/assets/images/collections/earrings/products/lumi-01.webp"
                        },
                        new Image() {
                            ProductId = 2,
                            Path = "/assets/images/collections/earrings/products/lumi-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Lela",
                    Slug = "bong-tai-lela",
                    Price = 175000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-LELA",
                    Ratings = 2,
                    Description = "Thêm chút phong cách trang nhã cho đôi tai của bạn với đôi bông tai ôm sát đầy tinh tế của Junie.\nBông taI Lumi được chế tác tỉ mỉ từ bạc 925 cao cấp, phủ một lớp dày vàng 14K, kết hợp với đá Cubic Zirconia lấp lánh tạo nên một thiết kế hoàn mỹ, là điểm nhấn duyên dáng trên vành tai nhỏ xinh của nàng.\nThiết kế đơn giản, nhưng không kém phần tinh tế để nàng có thể kết hợp cùng nhiều loại trang phục trong các dịp khác nhau như đi làm, đi chơi, thậm chí cả những bữa tiệc nhẹ nhàng.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 3,
                            Path = "/assets/images/collections/earrings/products/lela-01.webp"
                        },
                        new Image() {
                            ProductId = 3,
                            Path = "/assets/images/collections/earrings/products/lela-02.webp"
                        },
                    }
                },
            };

            _context.AddRange(products);
            _context.SaveChanges();

            return products;
        }

        private IList<Discount> AddDiscounts() {
            var discounts = new List<Discount>() {
                new() {
                    Code = "FREE_DELIVER_FEE",
                    Value = 30000,
                    MinPrice = 250000,
                    IsActive = true
                }
            };

            _context.AddRange(discounts);
            _context.SaveChanges();

            return discounts;
        }
    }
}
