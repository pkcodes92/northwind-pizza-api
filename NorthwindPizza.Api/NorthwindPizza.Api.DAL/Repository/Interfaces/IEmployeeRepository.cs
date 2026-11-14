// <copyright file="IEmployeeRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

using NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This interface defines methods that interact with the Employee database entity.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// This method definition returns all of the employees within the database.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="Employee"/>.</returns>
    Task<List<Employee>> GetAllEmployeesAsync();
}
