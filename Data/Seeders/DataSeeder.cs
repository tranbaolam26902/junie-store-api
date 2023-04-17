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
                    ImagePath = "/assets/images/collections/earrings/earrings.webp"
                },
                new() {
                    Title = "Dây Chuyền Nữ",
                    Description = "Chọn dây chuyền nàng yêu, làm những điều nàng thích",
                    Slug = "necklace",
                    ImagePath = "/assets/images/collections/necklace/necklace.webp"
                },
                new() {
                    Title = "Vòng Tay Nữ",
                    Description = "Lắc tay xinh xắn, thể hiện chất riêng",
                    Slug = "bracelet",
                    ImagePath = "/assets/images/collections/bracelet/bracelet.webp"
                },
                new() {
                    Title = "Nhẫn nữ",
                    Description = "Đeo nhẫn bạc, ngại gì tỏa sáng!",
                    Slug = "ring",
                    ImagePath = "/assets/images/collections/ring/ring.webp"
                },
                new() {
                    Title = "Bán chạy",
                    Description = "Luôn luôn bị thúc đẩy bởi niềm đam mê!",
                    Slug = "best-selling",
                    ImagePath = "/assets/images/collections/best-selling/best-selling.webp"
                },
                new() {
                    Title = "Sản phẩm mới",
                    Description = "Được tạo ra bằng tình yêu với thiết kế và chất lượng sản phẩm tốt.",
                    Slug = "new-in",
                    ImagePath = "/assets/images/collections/new-in/new-in.webp"
                },
                new() {
                    Title = "Sale Off",
                    Description = "Khám phá tất cả bộ sưu tập!",
                    Slug = "sale-outlet",
                    ImagePath = "/assets/images/collections/sale-outlet/sale-outlet.webp"
                },
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
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-03.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-04.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-05.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-06.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-07.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-08.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-09.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-10.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-11.webp"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "/assets/images/collections/earrings/products/jane-12.webp"
                        }
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
                new() {
                    Name = "Bông tai Gracie",
                    Slug = "bong-tai-gracie",
                    Price = 220000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-GRACIE",
                    Description = "Nếu nàng đang tìm kiếm một mẫu khuyên tai lấp lánh để hợp với chiếc đầm dạ hội trong bữa tiệc tối nay những lại đủ nhẹ nhàng để đi chơi, cafe cùng hội bạn dịp cuối tuần, thì Gracie chính là mẫu bông tai ngọc trai bạn đang tìm kiếm.\nChế tác trên nền bạc S925 (Sterling Silver) phủ một lớp vàng 14K sang trọng, bền bỉ khiến cho Gracie sẽ trở thành trợ thủ đắc lực của nàng mỗi ngày. Điểm nhấn là thiết kế dài/ngắn làm nên sự khác biệt cùng ngọc trai nước ngọt lấp lánh mang lại vẻ đẹp hoàn hảo nhưng rất dịu dàng.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 4,
                            Path = "/assets/images/collections/earrings/products/gracie-01.webp"
                        },
                        new Image() {
                            ProductId = 4,
                            Path = "/assets/images/collections/earrings/products/gracie-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Cilicia",
                    Slug = "bong-tai-cilicia",
                    Price = 190000,
                    Discount = 0.3f,
                    Quantity = 0,
                    Type = "E-CILICIA",
                    Ratings = 19,
                    Description = "Bông tai Cilicia được thiết kế như một cành hoa nhỏ đeo sát tai, với điểm nhấn là viên ngọc trai sáng bóng, mang lại nét đẹp tinh tế, dịu dàng và rạng rỡ cho các cô gái.\nHình chiếc lá nguyệt quế được chế tác tinh xảo bằng chất liệu bạc, phủ lên đó là lớp vàng 14K sang trọng. Hoàn thiện bằng đá CZ đính trên bề mặt lá giúp Cilicia trở nên lấp lánh và thu hút mọi ánh nhìn.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 5,
                            Path = "/assets/images/collections/earrings/products/cilicia-01.webp"
                        },
                        new Image() {
                            ProductId = 5,
                            Path = "/assets/images/collections/earrings/products/cilicia-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Fania",
                    Slug = "bong-tai-fania",
                    Price = 175000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-FANIA",
                    Ratings = 2,
                    Description = "Bông tai Fania được chế tác từ bạc 925 phủ vàng 14K kết hợp với đá CZ cao cấp. Kiểu dáng nhỏ nhắn, tinh tế mang đến cho các cô gái sự thanh lịch, nhẹ nhàng, phù hợp trong mọi hoàn cảnh và mọi trang phục.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 6,
                            Path = "/assets/images/collections/earrings/products/fania-01.webp"
                        },
                        new Image() {
                            ProductId = 6,
                            Path = "/assets/images/collections/earrings/products/fania-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Sophia",
                    Slug = "bong-tai-sophia",
                    Price = 220000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-SOPHIA",
                    Description = "Lấp lánh cùng những hình khối xếp thành từ những viên đá quý Zirconia có độ cứng hoàn hảo tạo nên nét duyên dáng không kém phần nổi bật cho nàng. Bông tai được chế tác tinh xảo từ nền bạc 925 dát một lớp vàng 14K dày dặn, cuối cùng được hoàn thiện bằng rất nhiều viên đá Zirconia lánh lánh tinh khiết.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 7,
                            Path = "/assets/images/collections/earrings/products/sophia-01.webp"
                        },
                        new Image() {
                            ProductId = 7,
                            Path = "/assets/images/collections/earrings/products/sophia-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Liko",
                    Slug = "bong-tai-liko",
                    Price = 180000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-LIKO",
                    Description = "Bông tai bạc 925 phủ vàng 14K được chế tác tinh xảo tạo nên một sản phẩm hoàn hảo. Với kiểu dáng nhỏ xinh, sản phẩm thích hợp cho những cô nàng theo phong cách dịu dàng, dễ thương.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 8,
                            Path = "/assets/images/collections/earrings/products/liko-01.webp"
                        },
                        new Image() {
                            ProductId = 8,
                            Path = "/assets/images/collections/earrings/products/liko-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Ava",
                    Slug = "bong-tai-ava",
                    Price = 125000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-AVA-3",
                    Description = "Chẳng cần đường nét cầu kỳ, chỉ đôi chấm nhỏ điểm xuyết vành tai xinh cũng đủ chinh phục mọi ánh nhìn. Thiết kế tối giản của bông tai nụ Ava là lựa chọn hoàn hảo cho mọi trang phục, mọi hoàn cảnh, mọi hình dáng khuôn mặt.\nHãy để cách đeo Ava nói lên tính cách của nàng: 1 đôi cho nhẹ nhàng chốn công sở; 2 chiếc 1 bên cho chút tinh nghịch xuống phố; hay cả 2 đôi tạo nét cá tính nhưng đầy quyến rũ cho đêm tiệc lung linh.\nSắc vàng của bông tai Ava có thể kết hợp linh hoạt với sắc trắng ngọc trai của mẫu bông tai Hope, hay ánh chiếu long lanh của mẫu Ivory. Nàng càng thêm nhiều lựa chọn để mix & match với trang phục.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 9,
                            Path = "/assets/images/collections/earrings/products/ava-01.webp"
                        },
                        new Image() {
                            ProductId = 9,
                            Path = "/assets/images/collections/earrings/products/ava-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Faustine",
                    Slug = "bong-tai-faustine",
                    Price = 180000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-FAUSTINE",
                    Description = "Bông tai Faustine được chế tác đầy độc đáo và bắt mắt. Kiểu dáng giúp các cô gái tôn lên vẻ thời trang và đầy ấn tượng, phù hợp với mọi kiểu trang phục.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 10,
                            Path = "/assets/images/collections/earrings/products/faustine-01.webp"
                        },
                        new Image() {
                            ProductId = 10,
                            Path = "/assets/images/collections/earrings/products/faustine-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Noemi",
                    Slug = "bong-tai-noemi",
                    Price = 220000,
                    Discount = 0.5f,
                    Quantity = 50,
                    Type = "E-NOEMI",
                    Ratings = 3,
                    Description = "Bông tai hình nơ dễ thương với thiết kế tinh xảo mang đến một sản phẩm ấn tượng cho các cô gái.\nĐiểm nhấn của bông tai là chiếc nơ xinh xắn được gắn đá Cubic Zirconia, mang đến vẻ đẹp ngọt ngào và đáng yêu.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 11,
                            Path = "/assets/images/collections/earrings/products/noemi-01.webp"
                        },
                        new Image() {
                            ProductId = 11,
                            Path = "/assets/images/collections/earrings/products/noemi-02.webp"
                        },
                    }
                },
                new() {
                    Name = "Bông tai Quinn",
                    Slug = "bong-tai-quinn",
                    Price = 250000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "E-QUINN",
                    Description = "Bông tai Quinn của Junie như một dấu ấn của sự tinh tế và rực rỡ, một phiên bản tự tin và lộng lẫy hơn dành cho các quý cô hiện đại.\nĐược chế tác từ tinh hoa của tự nhiên - Đá Cubic Zirconia lấp lánh tựa kim cương treo lơ lửng dưới chiếc khuyên được làm từ Bạc 925 phủ vàng 14K, tất cả tạo nên một tác phẩm sang trọng và không kém phần kiêu sa.\nNhư tất cả những người phụ nữ trên thế giới này, nàng xứng đáng nhận được tôn vinh bằng những điều tốt đẹp nhất. Hãy dành tặng bản thân một đôi bông tai đẹp đầy mê hoặc như Quinn để trở nên thật kiều diễm và thanh lịch.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[0],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 12,
                            Path = "/assets/images/collections/earrings/products/quinn-01.webp"
                        },
                        new Image() {
                            ProductId = 12,
                            Path = "/assets/images/collections/earrings/products/quinn-02.webp"
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
