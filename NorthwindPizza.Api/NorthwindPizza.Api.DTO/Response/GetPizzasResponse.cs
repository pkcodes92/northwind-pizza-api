// <copyright file="GetPizzasResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when getting all of the pizzas.
/// </summary>
public class GetPizzasResponse
{
    /// <summary>
    /// The list of the pizzas that have been retrieved.
    /// </summary>
    [JsonProperty("pizzas")]
    public List<Pizza> Pizzas { get; set; } = null!;
}
