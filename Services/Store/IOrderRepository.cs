using Core.Contracts;
using Core.Entities;

namespace Services.Store {
    public interface IOrderRepository {
        /// <summary>
        /// Create an Order
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Order creation state</returns>
        Task<bool> CreateOrderAsync(Order order, CancellationToken cancellationToken = default);

        /// <summary>
        /// Filter Orders by queries
        /// </summary>
        /// <param name="query">Order queries</param>
        /// <returns></returns>
        IQueryable<Order> FilterOrder(IOrderQuery query);

        /// <summary>
        /// Paginate orders filtered by queries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mapper"></param>
        /// <param name="query"></param>
        /// <param name="pagingParams"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IPagedList<T>> GetPagedOrdersByQueriesAsync<T>(Func<IQueryable<Order>, IQueryable<T>> mapper, IOrderQuery query, IPagingParams pagingParams, CancellationToken cancellationToken = default);

        /// <summary>
        /// Toggle order's confirmed state
        /// </summary>
        /// <param name="id">Order's id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> ToggleOrderConfirmedStateAsync(int id, CancellationToken cancellationToken = default);
    }
}
