// <copyright file="PatchOrderResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when an order is updated.
/// </summary>
public class PatchOrderResponse
{
    /// <summary>
    /// The updated order information.
    /// </summary>
    [JsonProperty("order")]
    public Order Order { get; set; } = null!;
}
