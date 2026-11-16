// <copyright file="CustomerRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository;

using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

/// <summary>
/// This class interacts with the Customer database entity.
/// </summary>
/// <remarks>
/// This class implements methods defined within <see cref="ICustomerRepository"/>.
/// </remarks>
/// <param name="context">The relevant database injection.</param>
public class CustomerRepository(NorthwindPizzaContext context) : ICustomerRepository
{
    private readonly NorthwindPizzaContext context = context;

    /// <summary>
    /// This method implementation will get a single customer.
    /// </summary>
    /// <param name="id">The ID of the customer to search.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Customer"/>.</returns>
    public async Task<Customer?> GetCustomerAsync(int id)
    {
        var dbCustomer = await this.context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        return dbCustomer!;
    }

    /// <summary>
    /// This method implementation will add a customer to the database.
    /// </summary>
    /// <param name="customer">The new customer information.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Customer"/>.</returns>
    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.CreatedAt))
        {
            customer.CreatedAt = null!;
        }

        this.context.Customers.Add(customer);
        var result = await this.context.SaveChangesAsync();
        return result > 0 ? customer! : null!;
    }

    /// <summary>
    /// This method implementation will get all the customers within the database.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="Customer"/>.</returns>
    public async Task<List<Customer>> GetCustomersAsync()
    {
        var dbResults = await this.context.Customers.ToListAsync();
        return dbResults!;
    }
}