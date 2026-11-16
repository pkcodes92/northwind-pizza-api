// <copyright file="Employee.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This class represents the Employee database entity.
/// </summary>
public partial class Employee
{
    /// <summary>
    /// The primary key of the employee.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// The first name of the employee.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the employee.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the employee.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The role of the employee.
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// A value that indicates whether or not the employee is active.
    /// </summary>
    public int IsActive { get; set; }
}
