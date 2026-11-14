// <copyright file="Customer.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Models;

using Newtonsoft.Json;

/// <summary>
/// This class represents the customer DTO entity.
/// </summary>
public class Customer
{
    /// <summary>
    /// The primary key of the customer entity.
    /// </summary>
    [JsonProperty("customerId")]
    public int CustomerId { get; set; }

    /// <summary>
    /// The first name of the customer.
    /// </summary>
    [JsonProperty("firstName")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the customer.
    /// </summary>
    [JsonProperty("lastName")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the customer.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The phone number of the customer.
    /// </summary>
    [JsonProperty("phone")]
    public string? Phone { get; set; }
}
