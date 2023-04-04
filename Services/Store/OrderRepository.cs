using Core.Entities;
using Data.Contexts;

namespace Services.Store {
    public class OrderRepository : IOrderRepository {
        private readonly StoreDbContext _context;

        public OrderRepository(StoreDbContext context) {
            _context = context;
        }

        public async Task<bool> CreateOrderAsync(Order order, CancellationToken cancellationToken = default) {
            if (order.Id == 0) {
                var totalPrice = order.OrderProducts.Sum(p => p.Price);
                var isFreeDelivery = false;
                SetDeliverFee(ref totalPrice, ref isFreeDelivery);

                if (order.Discount != null)
                    totalPrice = order.Discount.Value > 1
                        ? totalPrice - order.Discount.Value
                        : totalPrice * (1 - order.Discount.Value);

                order.OrderDate = DateTime.Now;
                order.TotalPrice = totalPrice;
                order.IsFreeDelivery = isFreeDelivery;

                await _context.Set<Order>()
                    .AddAsync(order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }

            return false;
        }

        private void SetDeliverFee(ref double totalPrice, ref bool isFreeDelivery) {
            var freeDeliveryDiscount = _context.Set<Discount>()
                .FirstOrDefault(x => x.Code == "FREE_DELIVER_FEE");

            if (totalPrice >= freeDeliveryDiscount.MinPrice) {
                isFreeDelivery = true;
            } else {
                totalPrice += freeDeliveryDiscount.Value;
                isFreeDelivery = false;
            }
        }
    }
}
