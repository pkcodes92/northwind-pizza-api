using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class GetCustomersResponse
{
    public List<Customer> Customers { get; set; } = new();
}
