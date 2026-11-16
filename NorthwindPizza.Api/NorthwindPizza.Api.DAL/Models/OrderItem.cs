// <copyright file="OrderItem.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This class represents the relevant OrderItem database entity.
/// </summary>
public partial class OrderItem
{
    /// <summary>
    /// The primary key of the order item.
    /// </summary>
    public int OrderItemId { get; set; }

    /// <summary>
    /// The primary key of the order.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// The primary key of the pizza.
    /// </summary>
    public int PizzaId { get; set; }

    /// <summary>
    /// The quantity of the pizza.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the pizza.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The sub-total for the line item in the order.
    /// </summary>
    public decimal LineTotal { get; set; }
}

/// <summary>
/// This class extends the type of <see cref="OrderItem"/>.
/// </summary>
public static class OrderItemExtensions
{
    /// <summary>
    /// This method converts a database entity to a DTO model.
    /// </summary>
    /// <param name="value">The relevant order item database entity.</param>
    /// <param name="pizza">The relevant pizza database entity.</param>
    /// <returns>A type of <see cref="DTO.Models.OrderItem"/>.</returns>
    public static DTO.Models.OrderItem ToDto(this OrderItem value, Pizza pizza)
    {
        return new DTO.Models.OrderItem
        {
            LineTotal = value.LineTotal,
            PizzaId = value.PizzaId,
            Quantity = value.Quantity,
            UnitPrice = value.UnitPrice,
            Name = pizza.Name,
        };
    }

    /// <summary>
    /// This method converts a database entity to a DTO model.
    /// </summary>
    /// <param name="value">The relevant order item database entity.</param>
    /// <returns>A type of <see cref="DTO.Models.OrderItem"/>.</returns>
    public static DTO.Models.OrderItem ToDto(this OrderItem value)
    {
        return new DTO.Models.OrderItem
        {
            LineTotal = value.LineTotal,
            PizzaId = value.PizzaId,
            Quantity = value.Quantity,
            UnitPrice = value.UnitPrice,
            Name = null!,
        };
    }
}