// <copyright file="CreateOrderItemRequest.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Request;

using Newtonsoft.Json;

/// <summary>
/// This class represents the request for an order item to be created.
/// </summary>
public class CreateOrderItemRequest
{
    /// <summary>
    /// The ID of the pizza for the new order item.
    /// </summary>
    [JsonProperty("pizzaId")]
    public int PizzaId { get; set; }

    /// <summary>
    /// The number of pizzas being ordered.
    /// </summary>
    [JsonProperty("quantity")]
    public int Quantity { get; set; }
}
