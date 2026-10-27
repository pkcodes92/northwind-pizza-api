using Microsoft.AspNetCore.Mvc;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Response;

namespace NorthwindPizza.Api.Controllers;

[ApiController]
[Tags("Orders")]
[Route("api/[controller]")]
public class OrderController(ILogger<OrderController> logger, IOrderRepository orderRepo) : ControllerBase
{
    private readonly ILogger<OrderController> logger = logger;

    private readonly IOrderRepository orderRepo = orderRepo;

    [HttpGet]
    public async Task<ActionResult<GetOrdersResponse>> GetOrdersAsync([FromQuery] int? statusId = null)
    {
        this.logger.LogInformation("Getting orders with status filter {StatusId}", statusId);

        var orders = await this.orderRepo.GetOrdersAsync(statusId);

        return this.Ok(new GetOrdersResponse
        {
            Orders = orders.Select(o => o.ToDto()).ToList()
        });
    }
}
