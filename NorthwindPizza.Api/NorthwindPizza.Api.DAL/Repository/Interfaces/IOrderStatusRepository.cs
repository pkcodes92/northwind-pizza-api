// <copyright file="IOrderStatusRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

using NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This interface defines the relevant methods that work with the OrderStatus database entity.
/// </summary>
public interface IOrderStatusRepository
{
    /// <summary>
    /// This method definition will get all the order statuses from the database.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="OrderStatus"/>.</returns>
    Task<List<OrderStatus>> GetOrderStatusesAsync();

    /// <summary>
    /// This method definition will get a single order status from the database.
    /// </summary>
    /// <param name="id">The primary key (integer) of the order status to search.</param>
    /// <returns>A unit of execution that contains a type of <see cref="OrderStatus"/>.</returns>
    Task<OrderStatus> GetOrderStatusAsync(int id);

    /// <summary>
    /// This method definition will get a single order status from the database.
    /// </summary>
    /// <param name="name">The name of the order status to search.</param>
    /// <returns>A unit of execution that contains a type of <see cref="OrderStatus"/>.</returns>
    Task<OrderStatus> GetOrderStatusAsync(string name);

    /// <summary>
    /// This method definition will add a new order status to the database.
    /// </summary>
    /// <param name="orderStatus">The relevant new order status information to add.</param>
    /// <returns>A unit of execution that contains a type of <see cref="OrderStatus"/>.</returns>
    Task<OrderStatus> AddOrderStatusAsync(OrderStatus orderStatus);

    /// <summary>
    /// This method definition will update an order status.
    /// </summary>
    /// <param name="orderStatus">The relevant order status information to update.</param>
    /// <returns>A unit of execution that contains a type of <see cref="OrderStatus"/>.</returns>
    Task<OrderStatus> UpdateOrderStatusAsync(OrderStatus orderStatus);

    /// <summary>
    /// This method definition will remove an order status from the database.
    /// </summary>
    /// <param name="id">The relevant primary key of the order status to remove.</param>
    /// <returns>A unit of execution that contains a boolean that indicates successful deletion.</returns>
    Task<bool> DeleteOrderStatusAsync(int id);
}
