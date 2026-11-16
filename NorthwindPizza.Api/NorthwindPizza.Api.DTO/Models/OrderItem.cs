// <copyright file="OrderItem.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Models;

using Newtonsoft.Json;

/// <summary>
/// This class represents the OrderItem DTO entity.
/// </summary>
public class OrderItem
{
    /// <summary>
    /// The primary key of the pizza.
    /// </summary>
    [JsonProperty("pizzaId")]
    public int PizzaId { get; set; }

    /// <summary>
    /// The name of the pizza.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The number of pizzas ordered.
    /// </summary>
    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the pizza.
    /// </summary>
    [JsonProperty("unitPrice")]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The calculation of the quantity * unitPrice.
    /// </summary>
    [JsonProperty("lineTotal")]
    public decimal LineTotal { get; set; }
}
