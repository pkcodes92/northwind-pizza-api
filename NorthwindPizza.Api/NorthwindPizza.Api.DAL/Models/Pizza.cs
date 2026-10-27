namespace NorthwindPizza.Api.DAL.Models;

public partial class Pizza
{
    public int PizzaId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal BasePrice { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public int IsActive { get; set; }
}

public static class PizzaExtensions
{
    public static DTO.Models.Pizza ToDto(this Pizza value)
    {
        return new DTO.Models.Pizza
        {
            Id = value.PizzaId,
            Name = value.Name,
            Description = value.Description,
            BasePrice = value.BasePrice,
            Image = value.ImageUrl,
            IsActive = value.IsActive == 1
        };
    }
}
