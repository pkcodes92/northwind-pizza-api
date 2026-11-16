// <copyright file="OrderStatus.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Models;

using Newtonsoft.Json;

/// <summary>
/// This class represents the order status DTO model.
/// </summary>
public class OrderStatus
{
    /// <summary>
    /// The primary key of the order status.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// The name of the order status.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The description of the order status.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The relevant display order of the order status.
    /// </summary>
    [JsonProperty("displayOrder")]
    public int DisplayOrder { get; set; }

    /// <summary>
    /// A value that indicates if the order status is active.
    /// </summary>
    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
}
