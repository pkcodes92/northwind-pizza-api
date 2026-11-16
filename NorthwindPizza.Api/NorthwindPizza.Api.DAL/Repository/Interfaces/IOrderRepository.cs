// <copyright file="IOrderRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

using NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This interface contains methods that interact with the Order database entity.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// This method definition gets all the orders from the database.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="Order"/>.</returns>
    Task<List<Order>> GetOrdersAsync();

    /// <summary>
    /// This method definition will create a new order in the database.
    /// </summary>
    /// <param name="order">The relevant order information.</param>
    /// <param name="orderItems">The list of the order items.</param>
    /// <returns>A unit of execution that contains a list of <see cref="Order"/>.</returns>
    Task<Order> CreateOrderAsync(Order order, List<OrderItem> orderItems);

    /// <summary>
    /// This method definition will get a single order from the database.
    /// </summary>
    /// <param name="id">The primary key of the order to search.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Order"/>.</returns>
    Task<Order?> GetOrderAsync(int id);

    /// <summary>
    /// This method definition will update an existing order in the database.
    /// </summary>
    /// <param name="order">The relevant order information to update.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Order"/>.</returns>
    Task<Order?> UpdateOrderAsync(Order order);
}