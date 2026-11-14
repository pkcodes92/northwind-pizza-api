// <copyright file="IOrderItemRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

using NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This interface defines methods that interact with the OrderItem database entity.
/// </summary>
public interface IOrderItemRepository
{
    /// <summary>
    /// This method definition will get all of the order items for an order.
    /// </summary>
    /// <param name="orderId">The ID of the order to search.</param>
    /// <returns>A unit of execution that contains a list of type <see cref="OrderItem"/>.</returns>
    Task<List<OrderItem>> GetOrderItemsAsync(int orderId);
}
