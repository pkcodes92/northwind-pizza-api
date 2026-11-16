// <copyright file="GetPizzaResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when getting a single pizza.
/// </summary>
public class GetPizzaResponse
{
    /// <summary>
    /// The relevant pizza that is retrieved.
    /// </summary>
    [JsonProperty("pizza")]
    public Pizza Pizza { get; set; } = null!;
}
