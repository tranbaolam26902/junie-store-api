using Api.Models;
using Core.Entities;
using MapsterMapper;
using Services.Store;
using System.Net;

namespace Api.Endpoints {
    public static class OrderEndpoints {
        public static WebApplication MapOrderEndpoints(this WebApplication app) {
            var routeGroupBuilder = app.MapGroup("/api/orders");

            routeGroupBuilder.MapPost("/", CreateOrder)
                .WithName("CreateOrder")
                .Produces<ApiResponse<string>>();

            return app;
        }

        private static async Task<IResult> CreateOrder(
            OrderModel order,
            IOrderRepository orderRepository,
            IMapper mapper) {
            return await orderRepository.CreateOrderAsync(mapper.Map<Order>(order))
                ? Results.Ok(ApiResponse.Success("Đặt hàng thành công!"))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.BadRequest, "Đặt hàng thất bại!"));
        }
    }
}
