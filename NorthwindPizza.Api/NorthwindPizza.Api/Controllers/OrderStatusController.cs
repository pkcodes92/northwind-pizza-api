using Microsoft.AspNetCore.Mvc;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Response;

namespace NorthwindPizza.Api.Controllers;

/// <summary>
/// This controller contains endpoints for the Order Status.
/// </summary>
/// <param name="orderStatusRepo">The relevant order status repository injection.</param>
/// <param name="logger">The relevant logging mechanism injection.</param>
[ApiController]
[Tags("Order Status")]
[Route("api/orderstatuses")]
public class OrderStatusController(IOrderStatusRepository orderStatusRepo, ILogger<OrderStatusController> logger) 
    : ControllerBase
{
    private readonly ILogger<OrderStatusController> logger = logger;

    private readonly IOrderStatusRepository orderStatusRepo = orderStatusRepo;

    /// <summary>
    /// This endpoint will get all of the order statuses from the database.
    /// </summary>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> that contains a type of
    /// <see cref="GetOrderStatusesResponse"/>.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<GetOrderStatusesResponse>> GetAllOrderStatusesAsync()
    {
        this.logger.LogInformation("Getting the order statuses from the database.");

        var dbOrderStatuses = await this.orderStatusRepo.GetOrderStatusesAsync();

        if (dbOrderStatuses is null)
        {
            return this.NotFound("The order statuses cannot be found!");
        }

        return this.StatusCode(StatusCodes.Status200OK, new GetOrderStatusesResponse
        {
            OrderStatuses = dbOrderStatuses.Select(x => x.ToDto()).ToList()
        });
    }

    /// <summary>
    /// This endpoint will get a single order status from the database.
    /// </summary>
    /// <param name="id">The relevant primary key of the order status.</param>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> which contains a type of
    /// <see cref="GetOrderStatusResponse"/>.
    /// </returns>
    [HttpGet("id")]
    public async Task<ActionResult<GetOrderStatusResponse>> GetOrderStatusByIdAsync([FromRoute] int id)
    {
        this.logger.LogInformation("Getting the order status by the ID");

        var dbOrderStatus = await this.orderStatusRepo.GetOrderStatusAsync(id);

        if (dbOrderStatus is null)
        {
            return this.NotFound("The order status cannot be found!");
        }

        return this.StatusCode(StatusCodes.Status200OK, new GetOrderStatusResponse
        {
            OrderStatus = dbOrderStatus.ToDto()
        });
    }
}
