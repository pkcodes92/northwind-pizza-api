// <copyright file="IPizzaRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

using NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This interface defines methods to interact with the Pizza database entity.
/// </summary>
public interface IPizzaRepository
{
    /// <summary>
    /// This method definition will get all the pizzas from the database.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="Pizza"/>.</returns>
    Task<List<Pizza>> GetAllPizzasAsync();

    /// <summary>
    /// This method definition will get a single pizza from the database.
    /// </summary>
    /// <param name="id">The primary key of the pizza to search.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Pizza"/>.</returns>
    Task<Pizza> GetPizzaAsync(int id);
}
