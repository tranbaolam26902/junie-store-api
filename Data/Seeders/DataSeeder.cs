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
                    ImagePath = "/assets/images/collections/earrings/earrings.jpg"
                },
                new() {
                    Title = "Dây Chuyền Nữ",
                    Description = "Chọn dây chuyền nàng yêu, làm những điều nàng thích",
                    Slug = "necklace",
                    ImagePath = "/assets/images/collections/necklace/necklace.jpg"
                },
                new() {
                    Title = "Vòng Tay Nữ",
                    Description = "Lắc tay xinh xắn, thể hiện chất riêng",
                    Slug = "bracelet",
                    ImagePath = "/assets/images/collections/bracelet/bracelet.jpg"
                },
                new() {
                    Title = "Nhẫn nữ",
                    Description = "Đeo nhẫn bạc, ngại gì tỏa sáng!",
                    Slug = "ring",
                    ImagePath = "/assets/images/collections/ring/ring.jpg"
                },
                new() {
                    Title = "Bán chạy",
                    Description = "Luôn luôn bị thúc đẩy bởi niềm đam mê!",
                    Slug = "best-selling",
                    ImagePath = "/assets/images/collections/best-selling/best-selling.jpg"
                },
                new() {
                    Title = "Sản phẩm mới",
                    Description = "Được tạo ra bằng tình yêu với thiết kế và chất lượng sản phẩm tốt.",
                    Slug = "new-in",
                    ImagePath = "/assets/images/collections/new-in/new-in.jpg"
                },
                new() {
                    Title = "Sale Off",
                    Description = "Khám phá tất cả bộ sưu tập!",
                    Slug = "sale-outlet",
                    ImagePath = "/assets/images/collections/sale-outlet/sale-outlet.jpg"
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
                            Path = "uploads/images/jane-01.jpg"
                        },
                        new Image() {
                            ProductId = 1,
                            Path = "uploads/images/jane-02.jpg"
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
                            Path = "uploads/images/lumi-01.jpg"
                        },
                        new Image() {
                            ProductId = 2,
                            Path = "uploads/images/lumi-02.jpg"
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
                            Path = "uploads/images/lela-01.jpg"
                        },
                        new Image() {
                            ProductId = 3,
                            Path = "uploads/images/lela-02.jpg"
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
                            Path = "uploads/images/gracie-01.jpg"
                        },
                        new Image() {
                            ProductId = 4,
                            Path = "uploads/images/gracie-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Dây chuyền Macy",
                    Slug = "day-chuyen-macy",
                    Price = 280000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "N-MACY",
                    Ratings = 0,
                    Description = "Chuỗi hạt ngọc trai mini này làm tăng nét cổ điển cho chiếc vòng cổ với một chút lấp lánh tinh tế trên mặt dây chuyền làm từ đá Cubic Zirconia.\nBộ dây chuyền layer này là sản phẩm mới nhất trong bộ sưu tập ngọc trai của Junie, mang đến cho nàng một lựa chọn hoàn hảo trong bất kỳ dịp nào cần sự nhẹ nhàng và dịu dàng như đi dự tiệc, hay đi chơi cùng bạn bè cuối tuần.\nHay, nếu bạn đang muốn tìm một mẫu vòng cổ ngọc trai mặc áo dài thì đây chắc chắn là một lựa chọn không thể bỏ qua.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[1],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 5,
                            Path = "uploads/images/macy-01.jpg"
                        },
                        new Image() {
                            ProductId = 5,
                            Path = "uploads/images/macy-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Dây chuyền Lily",
                    Slug = "day-chuyen-lily",
                    Price = 280000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "N-LILY",
                    Ratings = 2,
                    Description = "Cỏ bốn lá mang ý nghĩa may mắn đến cho người đeo, không chỉ dừng lại ở đó, Junie đã tiến thêm một bước nữa với thiết kế hai kiểu dáng đeo. Nàng có thể lựa chọn dáng đeo 4 hình trái tim hoặc ghép lại thành hình cỏ 4 lá may mắn.\nVới chất liệu hợp kim Titan vô cùng bền màu và cao cấp sau đó được dát vàng 14K sang trọng, tạo nên vẻ bề ngoài lấp lánh.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[1],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 6,
                            Path = "uploads/images/lily-01.jpg"
                        },
                        new Image() {
                            ProductId = 6,
                            Path = "uploads/images/lily-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Dây chuyền Raya",
                    Slug = "day-chuyen-raya",
                    Price = 350000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "N-RAYA",
                    Description = "Nằm trong bộ sưu tập ngọc trai nước ngọt của nhà Junie, mẫu dây chuyền Raya đã trở thành một món trang sức gây ấn tượng với thiết kế đơn giản, khiêm tốn nhưng ẩn chứa vẻ đẹp dịu dàng, sang trọng.\nViên ngọc trai sáng bóng treo dưới một nút thắt vàng lấp lánh tựa như ánh hoàng hôn rơi xuống những ngọn núi. Raya mang tới vẻ đẹp cuốn hút, kì diệu và đầy bí ẩn đến cho những cô nàng của Junie.\nĐiều đặc biệt ở dây chuyền Raya là có một thiết kế vừa đủ: không quá cầu kỳ - nàng có thể yên tâm phối với bộ cánh nhẹ nhàng xuống phố; nhưng cũng đủ diễm lệ cho những sự kiện quan trọng.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[1],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 7,
                            Path = "uploads/images/raya-01.jpg"
                        },
                        new Image() {
                            ProductId = 7,
                            Path = "uploads/images/raya-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Dây chuyền Abby",
                    Slug = "day-chuyen-abby",
                    Price = 340000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "N-ABBY",
                    Description = "Mặt dây chuyền hình trái tim luôn là món trang sức được các cô gái yêu chiều, một điểm nhấn nhỏ xinh nhưng khiến nàng trở nên thật dịu dàng và đáng yêu.\nChiếc vòng cổ quyến rũ hình trái tim này chế tác từ chất liệu Bạc 925 phủ vàng 14K cao cấp và có một hạt charm hình trái tim bằng xà cừ độc đáo.\nJunie gợi ý nàng có thể kết hợp chiếc vòng cổ này với một bông tai làm từ chất liệu tương tự hoặc họa tiết hình trái tim để tạo nên một bộ sưu tập hoàn hảo, giúp nàng tỏa sáng như ánh bình minh trên biển.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[1],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 8,
                            Path = "uploads/images/abby-01.jpg"
                        },
                        new Image() {
                            ProductId = 8,
                            Path = "uploads/images/abby-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Vòng tay Jenna",
                    Slug = "vong-tay-jenna",
                    Price = 230000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "B-JENNA",
                    Description = "Sản phẩm lắc tay Jenna siêu đẹp này được chế tác từ bạc 925 phủ một lớp dày vàng 14K sang trọng. Nổi bật với thiết kế đính đá Cubic Zirconia để tăng thêm vẻ quyến rũ tinh tế cho mọi dịp từ đi làm văn phòng đến những đêm dạ hội.\nHoàn hảo nhất khi đeo kết hợp dạng layer với những mẫu lắc tay khác tại Junie nhưng cũng không kém phần xinh đẹp khi đeo một mình. Lắc tay Jenna luôn là phụ kiện thời trang không thể thiếu của nàng khi muốn nổi bật cá tính riêng.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[2],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 9,
                            Path = "uploads/images/jenna-01.jpg"
                        },
                        new Image() {
                            ProductId = 9,
                            Path = "uploads/images/jenna-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Vòng tay Claire",
                    Slug = "vong-tay-claire",
                    Price = 260000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "B-CLAIRE",
                    Description = "Lấp lánh những hình trái tim bé xinh, vòng tay Claire dễ dàng trở thành một điểm nhấn mỏng manh tuyệt đẹp tôn lên cổ tay thanh mảnh của nàng.\nTình yêu luôn là nguồn cảm hứng bất tận của nghệ thuật. Dựa trên nguồn cảm hứng đó, Junie mang đến cho nàng mẫu vòng tay Claire với tạo hình những trái tim nhỏ bé được khảm bởi những viên đá CZ lấp lánh như kim cương - đẹp mơ mộng như chuyện tình của nàng Juliet.\nVới mẫu vòng tay này, nàng có thể thoải mái kết hợp với nhiều loại trang phục khác nhau từ đi học, đi làm hay đi chơi…",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[2],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 10,
                            Path = "uploads/images/claire-01.jpg"
                        },
                        new Image() {
                            ProductId = 10,
                            Path = "uploads/images/claire-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Vòng tay Sunny",
                    Slug = "vong-tay-sunny",
                    Price = 280000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "B-SUNNY",
                    Ratings = 3,
                    Description = "Toả sáng rực rỡ như một bông hồng dưới ánh mặt trời, vòng tay Sunny dễ dàng trở thành một điểm nhấn tuyệt đẹp tôn lên cổ tay thanh mảnh của cô gái đeo nó.\nThật không sai khi so sánh phụ nữ như những bông hoa, đều cần được chở che, chăm sóc, nâng niu thì mới càng nở rộ và trở nên xinh đẹp.\nDựa trên nguồn cảm hứng đó, Junie mang đến cho nàng mẫu vòng tay Sunny với tạo hình bông hồng được khảm bởi những viên đá CZ lấp lánh như kim cương - như một phiên bản thu nhỏ của chính nàng.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[2],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 11,
                            Path = "uploads/images/sunny-01.jpg"
                        },
                        new Image() {
                            ProductId = 11,
                            Path = "uploads/images/sunny-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Vòng tay Lena",
                    Slug = "vong-tay-lena",
                    Price = 175000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "B-LENA",
                    Description = "Chiếc lắc tay Lena trang nhã này với thiết kế các vòng tròn lồng vào nhau được chế tác bằng hợp kim Titan và được nhúng vào vàng 18k sang trọng.\nCó thể điều chỉnh độ dài với trọng lượng nhẹ, vòng đeo tay hình tròn lồng vào nhau Lena có một vòng với lớp bề mặt mịn và vòng thứ hai có thiết kế xoắn tinh tế đính đá Zirconia, làm cho nó trở thành một món đồ trang sức tinh tế vượt thời gian.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[2],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 12,
                            Path = "uploads/images/lena-01.jpg"
                        },
                        new Image() {
                            ProductId = 12,
                            Path = "uploads/images/lena-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Nhẫn Crossy",
                    Slug = "nhan-crossy",
                    Price = 210000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "R_CROSSY",
                    Description = "Nhẫn Crossy được xem là mảnh ghép hoàn hảo tạo nên vẻ đẹp đầy nữ tính và sang trọng cho nàng tự tin toả sáng.\nĐược chế tác bằng chất liệu bạc cao cấp 925 nhập khẩu, đính đá Cubic Zirconia có độ cứng hoàn hảo và lấp lánh như kim cương. Kết hợp với những đường nét uốn lượn mềm mại của biểu tượng Infinity (∞) hay còn gọi là “vô cực”. Giúp tạo điểm nhấn ấn tượng và nổi bật cho trang phục của nàng.\nBiểu tượng Infinity là sự không giới hạn, vĩnh cửu mà các nhà thiết kế của Junie thổi hồn vào trang sức như để thể hiện những khát khao yêu thương, niềm tin vào một tình yêu chân thành.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[3],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 13,
                            Path = "uploads/images/crossy-01.jpg"
                        },
                        new Image() {
                            ProductId = 13,
                            Path = "uploads/images/crossy-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Nhẫn Leaf",
                    Slug = "nhan-leaf",
                    Price = 195000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "R-LEAF",
                    Description = "Chiếc lá dịu dàng gợi nhớ đến mùa thu bình yên, thơ mộng và lãng mạn, nhẫn Leaf sẽ làm tôn lên nét đẹp yêu kiều, uyển chuyển của các cô gái trong mọi khoảnh khắc.\nNhững chiếc lá mong manh nhưng bền bỉ, đơn thuần nhưng thiết yếu, tràn đầy sức sống không mệt mỏi. Và Junie mong rằng, mỗi người đều có một tình yêu như vậy, có thể không vồn vã lãng mạn nhưng đôi bên đều hiểu rằng thuộc về nhau là điều đương nhiên.\nNhẫn Leaf là một món quà thích hợp để tặng người yêu hoặc nàng có thể tặng cho chính bản thân mình.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[3],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 14,
                            Path = "uploads/images/leaf-01.jpg"
                        },
                        new Image() {
                            ProductId = 14,
                            Path = "uploads/images/leaf-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Nhẫn Charlotte",
                    Slug = "nhan-charlotte",
                    Price = 230000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "R-CHARLOTTE",
                    Description = "Tinh tế, duyên dáng những vẫn sang trọng là những điều mà chúng ta sẽ cảm nhận được khi đeo trên mình các trang sức làm từ ngọc trai. Ẩn chứa trong mỗi viên ngọc trai đều là một vẻ đẹp đầy sự thu hút, mà càng nhìn lại càng thấy yêu hơn.\nLần đầu tiên cho ra mắt sản phẩm về nhẫn, Junie ưu ái mang tới sự kết hợp từ ngọc trai nước ngọt nhỏ nhắn nhưng không kém phần nổi bật và những viên đá Cubic Zirconia lấp lánh kiêu sa.\nMột chiếc nhẫn nhỏ xinh mà bạn có thể diện vào bất cứ lúc nào, bất cứ ở nơi đâu và bất cứ khi bạn muốn lựa chọn vẻ xinh đẹp riêng phù hợp với chính mình.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[3],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 15,
                            Path = "uploads/images/charlotte-01.jpg"
                        },
                        new Image() {
                            ProductId = 15,
                            Path = "uploads/images/charlotte-02.jpg"
                        },
                    }
                },
                new() {
                    Name = "Nhẫn Sense",
                    Slug = "nhan-sense",
                    Price = 210000,
                    Discount = 0,
                    Quantity = 50,
                    Type = "R-SENSE",
                    Description = "Đây chắc chắn là một món phụ kiện must-have dành cho những cô nàng theo đuổi phong cách trẻ trung, ngọt ngào.\nTạo hình giống như sợi ruy băng trắng tinh, thuần khiết nhẹ nhàng quấn lấy ngón tay nàng, nhẫn Sense giúp cho nàng trở nên dễ thương, xinh đẹp và “đính kèm” chút mơ mộng, dịu dàng.\nNhẫn Sense dễ dàng kết hợp với những bộ trang phục từ trong sáng, ngây thơ đến ngọt ngào, quyến rũ, hay từ đơn giản, nhẹ nhàng cho đến những bộ đồ sang trọng, lung linh.",
                    UserManual = "Được làm từ những chất liệu cao cấp và bền bỉ nhưng do đặc tính cơ bản của chất liệu, Junie khuyến khích khách hàng nên tuân theo các nguyên tắc bảo quản trang sức nói chung.\nNên tháo trang sức ra trước khi tiếp xúc với bất kỳ môi trường ẩm hoặc ma sát mạnh (vd: rửa tay, đi ngủ, tắm rửa,...) để đảm bảo và duy trì độ bóng của sản phẩm cũng như kéo dài tuổi thọ của sản phẩm.",
                    IsActive = true,
                    Collection = collections[3],
                    Images = new List<Image>() {
                        new Image() {
                            ProductId = 16,
                            Path = "uploads/images/sense-01.jpg"
                        },
                        new Image() {
                            ProductId = 16,
                            Path = "uploads/images/sense-02.jpg"
                        },
                    }
                }
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
