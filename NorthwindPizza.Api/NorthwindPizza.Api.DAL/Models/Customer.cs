namespace NorthwindPizza.Api.DAL.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string CreatedAt { get; set; } = string.Empty;
}

public static class CustomerExtensions
{
    public static DTO.Models.Customer ToDto(this Customer value)
    {
        return new DTO.Models.Customer
        {
            CustomerId = value.CustomerId,
            Email = value.Email,
            FirstName = value.FirstName,
            LastName = value.LastName,
            Phone = value.Phone
        };
    }
}