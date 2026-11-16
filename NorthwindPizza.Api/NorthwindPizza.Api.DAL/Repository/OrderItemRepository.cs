// <copyright file="OrderItemRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository;

using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

/// <summary>
/// This class implements the methods defined in <see cref="IOrderItemRepository"/>.
/// </summary>
/// <param name="context">The relevant database context inject.</param>
/// <remarks>
/// DONE: Define and implement a method to get all of the order items based on an order ID.
/// REVIEW: Define and implement a method to insert the relevant order items for a particular order.
/// </remarks>
public class OrderItemRepository(NorthwindPizzaContext context) : IOrderItemRepository
{
    private readonly NorthwindPizzaContext context = context;

    /// <summary>
    /// This method implementation will get the order items that belong to an order.
    /// </summary>
    /// <param name="orderId">The primary key of the order to search.</param>
    /// <returns>A unit of execution that contains a list of type <see cref="OrderItem"/>.</returns>
    public async Task<List<OrderItem>> GetOrderItemsAsync(int orderId)
    {
        var dbResults = await this.context.OrderItems.Where(g => g.OrderId == orderId).ToListAsync();
        return dbResults!;
    }
}
