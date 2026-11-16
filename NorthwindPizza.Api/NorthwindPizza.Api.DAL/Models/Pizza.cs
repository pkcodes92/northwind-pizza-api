// <copyright file="Pizza.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This class represents the relevant Pizza database entity.
/// </summary>
public partial class Pizza
{
    /// <summary>
    /// This is the primary key of the pizza.
    /// </summary>
    public int PizzaId { get; set; }

    /// <summary>
    /// The name of the pizza.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The description of the pizza.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The base price of the pizza.
    /// </summary>
    public decimal BasePrice { get; set; }

    /// <summary>
    /// The image of the pizza.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// An integer value that indicates if the pizza is active.
    /// </summary>
    public int IsActive { get; set; }
}

/// <summary>
/// This class extends the type of <see cref="Pizza"/>.
/// </summary>
public static class PizzaExtensions
{
    /// <summary>
    /// This method converts the database entity to a DTO model.
    /// </summary>
    /// <param name="value">The relevant Pizza database entity.</param>
    /// <returns>A type of <see cref="DTO.Models.Pizza"/>.</returns>
    public static DTO.Models.Pizza ToDto(this Pizza value)
    {
        return new DTO.Models.Pizza
        {
            Id = value.PizzaId,
            Name = value.Name,
            Description = value.Description,
            BasePrice = value.BasePrice,
            Image = value.ImageUrl,
            IsActive = value.IsActive == 1,
        };
    }
}
