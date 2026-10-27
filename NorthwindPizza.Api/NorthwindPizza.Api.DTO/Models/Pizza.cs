namespace NorthwindPizza.Api.DTO.Models;

public class Pizza
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal BasePrice { get; set; }

    public string Image { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}
