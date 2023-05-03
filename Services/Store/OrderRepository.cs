using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Services.Store {
    public class OrderRepository : IOrderRepository {
        private readonly StoreDbContext _context;

        public OrderRepository(StoreDbContext context) {
            _context = context;
        }

        public async Task<bool> CreateOrderAsync(Order order, CancellationToken cancellationToken = default) {
            if (order.Id == 0) {
                var totalPrice = order.OrderProducts.Sum(p => p.TotalPrice);
                var isFreeDelivery = false;
                SetDeliverFee(ref totalPrice, ref isFreeDelivery);

                if (order.Discount != null)
                    totalPrice = order.Discount.Value > 1
                        ? totalPrice - order.Discount.Value
                        : totalPrice * (1 - order.Discount.Value);

                order.OrderDate = DateTime.Now;
                order.TotalPrice = totalPrice;
                order.IsFreeDelivery = isFreeDelivery;

                foreach (var product in order.OrderProducts) {
                    await IncreaseProductTotalSoldAsync(product.ProductId, cancellationToken);
                    await DecreaseQuantityAsync(product.ProductId, product.Quantity, cancellationToken);
                }

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

        private async Task IncreaseProductTotalSoldAsync(int id, CancellationToken cancellationToken = default) {
            await _context.Set<Product>()
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(x => x.TotalSold, x => x.TotalSold + 1), cancellationToken);
        }

        private async Task DecreaseQuantityAsync(int id, int quantity, CancellationToken cancellationToken = default) {
            await _context.Set<Product>()
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(x => x.Quantity, x => x.Quantity - quantity), cancellationToken);
        }
    }
}
