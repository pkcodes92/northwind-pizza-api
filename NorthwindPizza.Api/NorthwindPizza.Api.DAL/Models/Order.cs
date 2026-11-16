// <copyright file="Order.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This class represents the Order database entity.
/// </summary>
public partial class Order
{
    /// <summary>
    /// The primary key of the order.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// The primary key of the customer.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// The relevant order status.
    /// </summary>
    public int OrderStatusId { get; set; }

    /// <summary>
    /// The date and time of the order date.
    /// </summary>
    public string OrderDate { get; set; } = string.Empty;

    /// <summary>
    /// The relevant total amount of the order.
    /// </summary>
    public decimal TotalAmount { get; set; }
}

/// <summary>
/// This class extends the type of <see cref="Order"/>.
/// </summary>
public static class OrderExtensions
{
    /// <summary>
    /// This method converts a database entity to a DTO model.
    /// </summary>
    /// <param name="value">The relevant order database entity.</param>
    /// <param name="orderStatus">The relevant order status database entity.</param>
    /// <param name="customer">The relevant customer database entity.</param>
    /// <returns>A type of <see cref="DTO.Models.Order"/>.</returns>
    public static DTO.Models.Order ToDto(this Order value, OrderStatus orderStatus, Customer customer)
    {
        return new DTO.Models.Order
        {
            Customer = customer.FullName(),
            Id = value.OrderId,
            OrderStatus = orderStatus.Name,
            OrderDate = value.OrderDate,
            TotalAmount = value.TotalAmount,
        };
    }
}