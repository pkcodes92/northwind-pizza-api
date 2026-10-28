using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class GetOrderStatusesResponse
{
    public List<OrderStatus> OrderStatuses { get; set; } = null!;
}
