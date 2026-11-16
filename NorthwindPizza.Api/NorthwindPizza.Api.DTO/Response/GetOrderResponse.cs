// <copyright file="GetOrderResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when getting a single order.
/// </summary>
public class GetOrderResponse
{
    /// <summary>
    /// The retrieved order information.
    /// </summary>
    [JsonProperty("order")]
    public Order Order { get; set; } = null!;
}
