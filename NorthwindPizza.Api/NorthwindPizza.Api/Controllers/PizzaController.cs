using Microsoft.AspNetCore.Mvc;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Response;

namespace NorthwindPizza.Api.Controllers;

/// <summary>
/// This controller will contain endpoints for the Pizza entity.
/// </summary>
/// <param name="logger">The relevant logging mechanism injection.</param>
/// <param name="pizzaRepo">The relevant pizza repository injection.</param>
[ApiController]
[Tags("Pizzas")]
[Route("api/pizzas")]
public class PizzaController(ILogger<PizzaController> logger, IPizzaRepository pizzaRepo) : ControllerBase
{
    private readonly ILogger<PizzaController> logger = logger;

    private readonly IPizzaRepository pizzaRepo = pizzaRepo;

    /// <summary>
    /// This method will get all of the pizzas in the database.
    /// </summary>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> which contains a type of
    /// <see cref="GetPizzasResponse"/>.
    /// </returns>
    [HttpGet("")]
    public async Task<ActionResult<GetPizzasResponse>> GetAllPizzasAsync()
    {
        this.logger.LogInformation("Getting all of the pizzas in the database");

        var dbPizzas = await this.pizzaRepo.GetAllPizzasAsync();

        var pizzas = dbPizzas.Select(x => x.ToDto()).ToList();

        return this.StatusCode(StatusCodes.Status200OK, new GetPizzasResponse
        {
            Pizzas = pizzas
        });
    }

    /// <summary>
    /// This method will get the relevant pizza by the ID.
    /// </summary>
    /// <param name="id">The primary key of the pizza to search.</param>
    /// <returns>
    /// A unit of execution that contains a type of <see cref="ActionResult{TValue}"/> which contains a type of
    /// <see cref="GetPizzaResponse"/>.
    /// </returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetPizzaResponse>> GetPizzaByIdAsync([FromRoute] int id)
    {
        this.logger.LogInformation("Getting pizza by ID {PizzaId}", id);

        var dbPizza = await this.pizzaRepo.GetPizzaAsync(id);

        if (dbPizza is null)
        {
            return this.StatusCode(StatusCodes.Status404NotFound, new ErrorResponse
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "The pizza cannot be found!"
            });
        }

        return this.StatusCode(StatusCodes.Status200OK, new GetPizzaResponse
        {
            Pizza = dbPizza.ToDto()
        });
    }
}
