using Microsoft.AspNetCore.Mvc;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Request;
using NorthwindPizza.Api.DTO.Response;

namespace NorthwindPizza.Api.Controllers;

[ApiController]
[Tags("Customers")]
[Route("api/[controller]")]
public class CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepo) : ControllerBase
{
    private readonly ILogger<CustomerController> logger = logger;

    private readonly ICustomerRepository customerRepo = customerRepo;

    [HttpPost]
    public async Task<ActionResult<GetCustomerResponse>> CreateCustomerAsync([FromBody] CreateCustomerRequest request)
    {
        this.logger.LogInformation("Creating customer");

        if (string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName) ||
            string.IsNullOrWhiteSpace(request.Email))
        {
            return this.BadRequest("First name, last name, and email are required.");
        }

        var normalizedFirstName = request.FirstName.Trim();
        var normalizedLastName = request.LastName.Trim();
        var normalizedEmail = request.Email.Trim();

        if (string.IsNullOrWhiteSpace(normalizedFirstName) ||
            string.IsNullOrWhiteSpace(normalizedLastName) ||
            string.IsNullOrWhiteSpace(normalizedEmail))
        {
            return this.BadRequest("First name, last name, and email cannot be empty.");
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

        return this.CreatedAtAction(nameof(this.GetCustomerByIdAsync), new { id = createdCustomer.CustomerId }, new GetCustomerResponse
        {
            Customer = new DTO.Models.Customer
            {
                CustomerId = createdCustomer.CustomerId,
                FirstName = createdCustomer.FirstName,
                LastName = createdCustomer.LastName,
                Email = createdCustomer.Email,
                Phone = createdCustomer.Phone
            }
        });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetCustomerResponse>> GetCustomerByIdAsync([FromRoute] int id)
    {
        this.logger.LogInformation("Getting customer by ID {CustomerId}", id);

        var customer = await this.customerRepo.GetCustomerAsync(id);

        if (customer is null)
        {
            return this.NotFound("The customer could not be found!");
        }

        return this.StatusCode(StatusCodes.Status200OK, new GetCustomerResponse
        {
            Customer = customer.ToDto()
        });
    }
}
