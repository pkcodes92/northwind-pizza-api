// <copyright file="Customer.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This class represents the relevant Customer database entity.
/// </summary>
public partial class Customer
{
    /// <summary>
    /// The primary key of the customer.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// The first name of the customer.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the customer.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the customer.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The phone number of the customer.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// The date and time that the customer is created.
    /// </summary>
    public string CreatedAt { get; set; } = string.Empty;
}

/// <summary>
/// This class extends the type of <see cref="Customer"/>.
/// </summary>
public static class CustomerExtensions
{
    /// <summary>
    /// This method will convert a database entity to a DTO model.
    /// </summary>
    /// <param name="value">The relevant customer database entity.</param>
    /// <returns>A type of <see cref="DTO.Models.Customer"/>.</returns>
    public static DTO.Models.Customer ToDto(this Customer value)
    {
        return new DTO.Models.Customer
        {
            CustomerId = value.CustomerId,
            Email = value.Email,
            FirstName = value.FirstName,
            LastName = value.LastName,
            Phone = value.Phone,
        };
    }

    /// <summary>
    /// This method will return the necessary full name of the customer.
    /// </summary>
    /// <param name="value">The relevant customer database entity.</param>
    /// <returns>A string that represents the full name.</returns>
    public static string FullName(this Customer value)
    {
        return $"{value.FirstName} {value.LastName}";
    }
}