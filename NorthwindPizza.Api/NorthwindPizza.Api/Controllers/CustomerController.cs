using Microsoft.AspNetCore.Mvc;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Request;
using NorthwindPizza.Api.DTO.Response;

namespace NorthwindPizza.Api.Controllers;

/// <summary>
/// This class contains endpoints for the Customer entity.
/// </summary>
/// <param name="logger">The relevant logging mechanism injection.</param>
/// <param name="customerRepo">The relevant customer repository injection.</param>
[ApiController]
[Tags("Customers")]
[Route("api/customers")]
public class CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepo) : ControllerBase
{
    private readonly ILogger<CustomerController> logger = logger;

    private readonly ICustomerRepository customerRepo = customerRepo;

    /// <summary>
    /// This endpoint will add a new customer to the database.
    /// </summary>
    /// <param name="request">The new customer that is being added.</param>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> that contains a type of
    /// <see cref="GetCustomerResponse"/>.
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<GetCustomerResponse>> CreateCustomerAsync([FromBody] CreateCustomerRequest request)
    {
        this.logger.LogInformation("Creating customer");

        if (string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName) ||
            string.IsNullOrWhiteSpace(request.Email))
        {
            return this.StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "First name, last name, and email are required."
            });
        }

        var normalizedFirstName = request.FirstName.Trim();
        var normalizedLastName = request.LastName.Trim();
        var normalizedEmail = request.Email.Trim();

        if (string.IsNullOrWhiteSpace(normalizedFirstName) ||
            string.IsNullOrWhiteSpace(normalizedLastName) ||
            string.IsNullOrWhiteSpace(normalizedEmail))
        {
            return this.StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse 
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "First name, last name, and email cannot be empty."
            });
        }

        var customer = new Customer
        {
            FirstName = normalizedFirstName,
            LastName = normalizedLastName,
            Email = normalizedEmail,
            Phone = string.IsNullOrWhiteSpace(request.Phone) ? null : request.Phone.Trim(),
            CreatedAt = string.Empty
        };

        var createdCustomer = await this.customerRepo.AddCustomerAsync(customer);

        return this.StatusCode(StatusCodes.Status201Created, new GetCustomerResponse
        {
            Customer = createdCustomer.ToDto()
        });
    }

    /// <summary>
    /// This endpoint will get a single customer to the database.
    /// </summary>
    /// <param name="id">The primary key of the customer to search.</param>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> that contains a type of
    /// <see cref="GetCustomerResponse"/>.
    /// </returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetCustomerResponse>> GetCustomerByIdAsync([FromRoute] int id)
    {
        this.logger.LogInformation("Getting customer by ID {CustomerId}", id);

        var customer = await this.customerRepo.GetCustomerAsync(id);

        if (customer is null)
        {
            return this.StatusCode(StatusCodes.Status404NotFound, new ErrorResponse
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "The customer could not be found!"
            });
        }

        return this.StatusCode(StatusCodes.Status200OK, new GetCustomerResponse
        {
            Customer = customer.ToDto()
        });
    }

    /// <summary>
    /// This endpoint will get all of the customers from the database.
    /// </summary>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> which then contains a type of
    /// <see cref="GetCustomersResponse"/>.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<GetCustomersResponse>> GetCustomersAsync()
    {
        this.logger.LogInformation("Getting all customers");

        var dbCustomers = await this.customerRepo.GetCustomersAsync();

        if (dbCustomers is null)
        {
            return this.StatusCode(StatusCodes.Status404NotFound, new ErrorResponse
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "The customers cannot be found!"
            });
        }

        return this.StatusCode(StatusCodes.Status200OK, new GetCustomersResponse
        {
            Customers = dbCustomers.Select(x => x.ToDto()).ToList()
        });
    }
}
