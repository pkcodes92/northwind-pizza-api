// <copyright file="CreateCustomerRequest.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Request;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// This class represents the request when creating a new customer.
/// </summary>
public class CreateCustomerRequest
{
    /// <summary>
    /// The first name of the new customer.
    /// </summary>
    [Required]
    [MinLength(1)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the new customer.
    /// </summary>
    [Required]
    [MinLength(1)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the new customer.
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The phone number of the new customer.
    /// </summary>
    public string? Phone { get; set; }
}
