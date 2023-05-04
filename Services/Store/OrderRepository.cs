using Core.Contracts;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;

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

        public IQueryable<Order> FilterOrder(IOrderQuery query) {
            IQueryable<Order> orderQuery = _context.Set<Order>()
                .Include(o => o.OrderProducts);

            if (!string.IsNullOrWhiteSpace(query.Keyword)) {
                orderQuery = orderQuery.Where(
                    p => p.Name.ToLower().Contains(query.Keyword.ToLower()) ||
                        p.PhoneNumber.Contains(query.Keyword) ||
                        p.Email.ToLower().Contains(query.Keyword.ToLower()) ||
                        p.Address.ToLower().Contains(query.Keyword.ToLower()) ||
                        p.AddressDescription.ToLower().Contains(query.Keyword.ToLower()) ||
                        p.Notes.ToLower().Contains(query.Keyword.ToLower())
                );
            }

            if (query.IsNotConfirmed) {
                orderQuery = orderQuery.Where(p => p.IsConfirmed == false);
            }

            return orderQuery;
        }

        public async Task<IPagedList<T>> GetPagedOrdersByQueriesAsync<T>(Func<IQueryable<Order>, IQueryable<T>> mapper, IOrderQuery query, IPagingParams pagingParams, CancellationToken cancellationToken = default) {
            return await mapper(FilterOrder(query).AsNoTracking()).ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<bool> ToggleOrderConfirmedStateAsync(int id, CancellationToken cancellationToken = default) {
            await _context.Set<Order>()
                .Where(o => o.Id == id)
                .ExecuteUpdateAsync(o => o.SetProperty(o => o.IsConfirmed, o => !o.IsConfirmed), cancellationToken);
            var order = await _context.Set<Order>()
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            return order.IsConfirmed;
        }
    }
}
