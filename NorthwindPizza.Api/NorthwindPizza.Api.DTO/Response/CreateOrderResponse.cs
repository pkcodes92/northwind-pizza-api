// <copyright file="CreateOrderResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when a new order is created.
/// </summary>
public class CreateOrderResponse
{
    /// <summary>
    /// The newly created order.
    /// </summary>
    [JsonProperty("order")]
    public Order Order { get; set; } = null!;
}
