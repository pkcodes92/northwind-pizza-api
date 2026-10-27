using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class GetCustomerResponse
{
    public Customer Customer { get; set; } = null!;
}
