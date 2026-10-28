using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class GetOrderStatusResponse
{
    public OrderStatus OrderStatus { get; set; } = null!;
}
