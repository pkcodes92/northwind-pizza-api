// <copyright file="PizzaRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository;

using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

/// <summary>
/// This class implements methods that have been defined in <see cref="IPizzaRepository"/>.
/// </summary>
/// <param name="context">The relevant database context injection.</param>
public class PizzaRepository(NorthwindPizzaContext context) : IPizzaRepository
{
    private readonly NorthwindPizzaContext context = context;

    public async Task<List<Pizza>> GetAllPizzasAsync()
    {
        var dbResults = await this.context.Pizzas.Where(p => p.IsActive == 1).ToListAsync();
        return dbResults!;
    }

    public async Task<Pizza> GetPizzaAsync(int id)
    {
        var dbResult = await this.context.Pizzas.FirstOrDefaultAsync(p => p.PizzaId == id && p.IsActive == 1);
        return dbResult!;
    }
}
