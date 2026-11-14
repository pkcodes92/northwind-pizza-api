// <copyright file="OrderItem.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

using Newtonsoft.Json;

namespace NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the OrderItem DTO entity.
/// </summary>
public class OrderItem
{
    [JsonProperty("pizzaId")]
    public int PizzaId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("unitPrice")]
    public decimal UnitPrice { get; set; }

    [JsonProperty("lineTotal")]
    public decimal LineTotal { get; set; }
}
