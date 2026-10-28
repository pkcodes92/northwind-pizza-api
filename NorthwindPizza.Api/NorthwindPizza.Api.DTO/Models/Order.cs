namespace NorthwindPizza.Api.DTO.Models;

public class Order
{
    public int Id { get; set; }

    public string Customer { get; set; } = string.Empty;

    public string OrderStatus { get; set; } = string.Empty;

    public string OrderDate { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public List<OrderItem> Items { get; set; } = null!;
}
