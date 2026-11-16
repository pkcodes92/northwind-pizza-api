// <copyright file="Pizza.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Models;

using Newtonsoft.Json;

/// <summary>
/// This class represents the pizza DTO model.
/// </summary>
public class Pizza
{
    /// <summary>
    /// The primary key of the pizza.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// The name of the pizza.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The description of the pizza.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The base price of the pizza.
    /// </summary>
    [JsonProperty("basePrice")]
    public decimal BasePrice { get; set; }

    /// <summary>
    /// The relevant image URL of the pizza.
    /// </summary>
    [JsonProperty("image")]
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether the pizza is active.
    /// </summary>
    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
}
