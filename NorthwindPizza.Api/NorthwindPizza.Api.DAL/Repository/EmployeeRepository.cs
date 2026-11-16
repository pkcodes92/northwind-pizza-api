// <copyright file="EmployeeRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository;

using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

/// <summary>
/// This class contains methods that interact with the Employee database entity.
/// </summary>
/// <remarks>
/// This class implements methods that are defined in <see cref="IEmployeeRepository"/>.
/// </remarks>
/// <param name="context">The relevant database context injection.</param>
public class EmployeeRepository(NorthwindPizzaContext context) : IEmployeeRepository
{
    private readonly NorthwindPizzaContext context = context;

    /// <summary>
    /// This method will get all of the employees in the database.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="Employee"/>.</returns>
    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        var dbResults = await this.context.Employees.Where(g => g.IsActive == 1).ToListAsync();
        return dbResults!;
    }
}
