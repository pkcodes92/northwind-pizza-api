using NorthwindPizza.Api.DAL.Models;

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomersAsync();

    Task<Customer?> GetCustomerAsync(int id);

    Task<Customer> AddCustomerAsync(Customer customer);
}
