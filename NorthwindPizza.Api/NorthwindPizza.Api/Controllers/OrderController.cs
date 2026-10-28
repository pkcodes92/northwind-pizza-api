using Microsoft.AspNetCore.Mvc;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Request;
using NorthwindPizza.Api.DTO.Response;
using NorthwindPizza.Api.Services.Interfaces;

namespace NorthwindPizza.Api.Controllers;

/// <summary>
/// This class contains all the relevant endpoints for the Order entity.
/// </summary>
/// <remarks>
/// DONE: Implement the endpoint of POST /api/orders
/// DONE: Implement the endpoint of GET /api/orders/{id}
/// TODO: Implement the endpoint of PATCH /api/orders/{id}/status
/// </remarks>
/// <param name="logger">The relevant logging mechanism injection.</param>
/// <param name="orderRepo">The necessary order repository injection.</param>
/// <param name="orderSvc">The relevant order service injection.</param>
/// <param name="orderItemRepo">The relevant order item repository injection.</param>
[ApiController]
[Tags("Orders")]
[Route("api/orders")]
public class OrderController(
    ILogger<OrderController> logger,
    IOrderRepository orderRepo,
    IOrderService orderSvc,
    IOrderItemRepository orderItemRepo) : ControllerBase
{
    private readonly ILogger<OrderController> logger = logger;

    private readonly IOrderRepository orderRepo = orderRepo;

    private readonly IOrderService orderSvc = orderSvc;

    private readonly IOrderItemRepository orderItemRepo = orderItemRepo;

    /// <summary>
    /// This endpoint will get all of the various orders from the database.
    /// </summary>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> that contains a type of
    /// <see cref="GetOrdersResponse"/>.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<GetOrdersResponse>> GetOrdersAsync()
    {
        this.logger.LogInformation("Getting all the orders");

        var orders = await this.orderRepo.GetOrdersAsync();

        return this.Ok(new GetOrdersResponse
        {
            Orders = orders.Select(o => o.ToDto()).ToList()
        });
    }

    /// <summary>
    /// This endpoint will creating a new order and saving it to the database.
    /// </summary>
    /// <param name="request">The new order information to be saved.</param>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> which contains a type of
    /// <see cref="CreateOrderResponse"/>.
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> CreateOrderAsync([FromBody] CreateOrderRequest request)
    {
        this.logger.LogInformation("Creating a new order");

        var createdOrder = await this.orderSvc.CreateOrderAsync(request);

        var orderItems = await this.orderItemRepo.GetOrderItemsAsync(createdOrder!.Id);

        createdOrder.Items = orderItems.Select(x => x.ToDto()).ToList();

        return this.StatusCode(StatusCodes.Status201Created, new CreateOrderResponse
        {
            Order = createdOrder!,
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetOrderResponse>> GetOrderAsync([FromRoute] int id)
    {
        this.logger.LogInformation("Getting the order by the ID");

        var dbOrder = await this.orderRepo.GetOrderAsync(id);

        if (dbOrder is not null)
        {
            var dbOrderItems = await this.orderItemRepo.GetOrderItemsAsync(dbOrder.OrderId);

            var order = dbOrder.ToDto();

            order.Items = dbOrderItems.Select(oi => oi.ToDto()).ToList();

            return this.StatusCode(StatusCodes.Status200OK, new GetOrderResponse
            {
                Order = order
            });
        }

        return this.NotFound("The order could not be found!");
    }
}
