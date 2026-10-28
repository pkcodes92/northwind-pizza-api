using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class PatchOrderResponse
{
    public Order Order { get; set; } = null!;
}
