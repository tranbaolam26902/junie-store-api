using Core.Entities;

namespace Services.Store {
    public interface IOrderRepository {
        /// <summary>
        /// Create an Order
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Order creation state</returns>
        Task<bool> CreateOrderAsync(Order order, CancellationToken cancellationToken = default);
    }
}
