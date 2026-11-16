// <copyright file="CreateOrderRequest.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Request;

using Newtonsoft.Json;

/// <summary>
/// This class represents the request when creating a new order.
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// The relevant customer ID.
    /// </summary>
    [JsonProperty("customerId")]
    public int CustomerId { get; set; }

    /// <summary>
    /// The relevant order items.
    /// </summary>
    [JsonProperty("items")]
    public List<CreateOrderItemRequest> Items { get; set; } = null!;
}
