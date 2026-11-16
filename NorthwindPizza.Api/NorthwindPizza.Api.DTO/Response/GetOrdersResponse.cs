// <copyright file="GetOrdersResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when getting the orders.
/// </summary>
public class GetOrdersResponse
{
    /// <summary>
    /// The list of the orders.
    /// </summary>
    [JsonProperty("orders")]
    public List<Order> Orders { get; set; } = null!;
}