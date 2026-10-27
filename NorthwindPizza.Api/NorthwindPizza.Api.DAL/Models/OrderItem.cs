namespace NorthwindPizza.Api.DAL.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int PizzaId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }
}

public static class OrderItemExtensions
{
    public static DTO.Models.OrderItem ToDto(this OrderItem value)
    {
        return new DTO.Models.OrderItem
        {
            LineTotal = value.LineTotal,
            PizzaId = value.PizzaId,
            Quantity = value.Quantity,
            UnitPrice = value.UnitPrice
        };
    }
}