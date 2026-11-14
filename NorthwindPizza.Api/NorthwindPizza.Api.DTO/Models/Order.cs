// <copyright file="Order.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Models;

using Newtonsoft.Json;

/// <summary>
/// This class represents the Order DTO model.
/// </summary>
public class Order
{
    /// <summary>
    /// The primary key of the order entity.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// The relevant customer for the order.
    /// </summary>
    [JsonProperty("customer")]
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// The order status.
    /// </summary>
    [JsonProperty("orderStatus")]
    public string OrderStatus { get; set; } = string.Empty;

    /// <summary>
    /// The date of the order.
    /// </summary>
    [JsonProperty("orderDate")]
    public string OrderDate { get; set; } = string.Empty;

    /// <summary>
    /// The total amount of the order.
    /// </summary>
    [JsonProperty("totalAmount")]
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The relevant items of the order.
    /// </summary>
    [JsonProperty("items")]
    public List<OrderItem> Items { get; set; } = null!;
}
