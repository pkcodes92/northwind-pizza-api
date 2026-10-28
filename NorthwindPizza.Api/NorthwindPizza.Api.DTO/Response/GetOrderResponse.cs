using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class GetOrderResponse
{
    public Order Order { get; set; } = null!;
}
