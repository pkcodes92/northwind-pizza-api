// <copyright file="PatchOrderRequest.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Request;

using Newtonsoft.Json;

/// <summary>
/// This class represents the request to update/patch an order.
/// </summary>
public class PatchOrderRequest
{
    /// <summary>
    /// The relevant order status that is to be updated.
    /// </summary>
    [JsonProperty("statusId")]
    public int StatusId { get; set; }
}
