using Api.Filters;
using Api.Models;
using Core.Collections;
using Core.DTO;
using Core.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Queries;
using Services.Store;
using System.Net;

namespace Api.Endpoints {
    public static class OrderEndpoints {
        public static WebApplication MapOrderEndpoints(this WebApplication app) {
            var routeGroupBuilder = app.MapGroup("/api/orders");

            routeGroupBuilder.MapPost("/", CreateOrder)
                .WithName("CreateOrder")
                .AddEndpointFilter<ValidatorFilter<OrderModel>>()
                .Produces<ApiResponse<bool>>();

            routeGroupBuilder.MapGet("/", GetOrdersByQueries)
                .WithName("GetOrdersByQueries")
                .Produces<ApiResponse<PaginationResult<OrderDTO>>>();

            routeGroupBuilder.MapPost("/{id:int}", ToggleOrderConfirmedState)
                .WithName("ToggleOrderConfirmedState")
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

        private static async Task<IResult> GetOrdersByQueries(
            [AsParameters] OrderFilterModel model,
            IMapper mapper,
            IOrderRepository orderRepository) {
            var query = mapper.Map<OrderQuery>(model);
            var orders = await orderRepository.GetPagedOrdersByQueriesAsync(p => p.ProjectToType<OrderDTO>(), query, model);
            var paginationResult = new PaginationResult<OrderDTO>(orders);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> ToggleOrderConfirmedState(
            [FromRoute] int id,
            IOrderRepository orderRepository) {
            return Results.Ok(ApiResponse.Success(await orderRepository.ToggleOrderConfirmedStateAsync(id)));
        }
    }
}
