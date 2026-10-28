using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class CreateOrderResponse
{
    public Order Order { get; set; } = null!;
}
