// <copyright file="ICustomerRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

using NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This interface defines methods that interact with the Customer database entity.
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// This method definition will get all the customers in the database.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="Customer"/>.</returns>
    Task<List<Customer>> GetCustomersAsync();

    Task<Customer?> GetCustomerAsync(int id);

    Task<Customer> AddCustomerAsync(Customer customer);
}
