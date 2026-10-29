namespace NorthwindPizza.Api.DTO.Models;

public class OrderItem
{
    public int PizzaId { get; set; }

    public string? Name { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }
}
