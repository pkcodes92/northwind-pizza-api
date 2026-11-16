// <copyright file="GetOrderStatusesResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the relevant response when getting the order statuses.
/// </summary>
public class GetOrderStatusesResponse
{
    /// <summary>
    /// The relevant list of the order statuses.
    /// </summary>
    [JsonProperty("orderStatuses")]
    public List<OrderStatus> OrderStatuses { get; set; } = null!;
}
