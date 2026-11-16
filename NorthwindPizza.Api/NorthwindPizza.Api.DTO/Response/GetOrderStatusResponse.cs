// <copyright file="GetOrderStatusResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when getting a single order status.
/// </summary>
public class GetOrderStatusResponse
{
    /// <summary>
    /// The relevant order status that is retrieved.
    /// </summary>
    [JsonProperty("orderStatus")]
    public OrderStatus OrderStatus { get; set; } = null!;
}
