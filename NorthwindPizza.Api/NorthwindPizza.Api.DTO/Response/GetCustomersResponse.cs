// <copyright file="GetCustomersResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when getting the customers.
/// </summary>
public class GetCustomersResponse
{
    /// <summary>
    /// The list of the customers.
    /// </summary>
    [JsonProperty("customers")]
    public List<Customer> Customers { get; set; } = new();
}
