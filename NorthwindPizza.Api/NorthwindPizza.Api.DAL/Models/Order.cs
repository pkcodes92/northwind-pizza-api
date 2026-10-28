namespace NorthwindPizza.Api.DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int OrderStatusId { get; set; }

    public string OrderDate { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }
}

public static class OrderExtensions
{
    public static DTO.Models.Order ToDto(this Order value, OrderStatus orderStatus, Customer customer)
    {
        return new DTO.Models.Order
        {
            Customer = customer.FullName(),
            Id = value.OrderId,
            OrderStatus = orderStatus.Name,
            OrderDate = value.OrderDate,
            TotalAmount = value.TotalAmount
        };
    }
}