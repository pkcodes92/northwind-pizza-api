// <copyright file="GetCustomerResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;
using NorthwindPizza.Api.DTO.Models;

/// <summary>
/// This class represents the response when getting a customer.
/// </summary>
public class GetCustomerResponse
{
    /// <summary>
    /// The customer that has been retrieved.
    /// </summary>
    [JsonProperty("customer")]
    public Customer Customer { get; set; } = null!;
}
