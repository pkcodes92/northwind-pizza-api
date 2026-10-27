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
/// TODO: Implement the endpoint of GET /api/orders/{id}
/// TODO: Implement the endpoint of PATCH /api/orders/{id}/status
/// </remarks>
/// <param name="logger">The relevant logging mechanism injection.</param>
/// <param name="orderRepo">The necessary order repository injection.</param>
/// <param name="orderSvc">The relevant order service injection.</param>
[ApiController]
[Tags("Orders")]
[Route("api/orders")]
public class OrderController(ILogger<OrderController> logger, IOrderRepository orderRepo, IOrderService orderSvc) : ControllerBase
{
    private readonly ILogger<OrderController> logger = logger;

    private readonly IOrderRepository orderRepo = orderRepo;

    private readonly IOrderService orderSvc = orderSvc;

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

        return this.StatusCode(StatusCodes.Status201Created, new CreateOrderResponse
        {
            Order = createdOrder!,
        });
    }
}
