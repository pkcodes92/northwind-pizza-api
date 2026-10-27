using Microsoft.AspNetCore.Mvc;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Response;

namespace NorthwindPizza.Api.Controllers;

/// <summary>
/// This controller will contain endpoints for the Pizza entity.
/// </summary>
[ApiController]
[Tags("Pizzas")]
[Route("api/[controller]")]
public class PizzaController(ILogger<PizzaController> logger, IPizzaRepository pizzaRepo) : ControllerBase
{
    private readonly ILogger<PizzaController> logger = logger;

    private readonly IPizzaRepository pizzaRepo = pizzaRepo;

    [HttpGet("")]
    public async Task<ActionResult<GetPizzasResponse>> GetAllPizzasAsync()
    {
        this.logger.LogInformation("Getting all of the pizzas in the database");

        var dbPizzas = await this.pizzaRepo.GetAllPizzasAsync();

        if (dbPizzas is null)
        {
            return this.NotFound("Not able to get the pizzas from the database!");
        }

        var pizzas = dbPizzas.Select(x => x.ToDto()).ToList();

        return this.StatusCode(StatusCodes.Status200OK, new GetPizzasResponse
        {
            Pizzas = pizzas
        });
    }
}
