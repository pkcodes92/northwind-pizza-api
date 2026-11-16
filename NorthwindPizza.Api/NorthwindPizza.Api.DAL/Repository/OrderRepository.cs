// <copyright file="OrderRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository;

using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

/// <summary>
/// This class contains methods that interact with the Order database entity.
/// </summary>
/// <param name="context">The relevant database context injection.</param>
public class OrderRepository(NorthwindPizzaContext context) : IOrderRepository
{
    private readonly NorthwindPizzaContext context = context;

    /// <summary>
    /// This method implementation will add a new order to the database.
    /// </summary>
    /// <param name="order">The relevant order information to be added.</param>
    /// <param name="orderItems">The list of the items that is part of the order.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Order"/>.</returns>
    public async Task<Order> CreateOrderAsync(Order order, List<OrderItem> orderItems)
    {
        await using var transaction = await this.context.Database.BeginTransactionAsync();

        try
        {
            this.context.Orders.Add(order);
            await this.context.SaveChangesAsync();

            foreach (var item in orderItems)
            {
                item.OrderId = order.OrderId;
            }

            // Save the order items.
            this.context.OrderItems.AddRange(orderItems);
            await this.context.SaveChangesAsync();

            await transaction.CommitAsync();

            return order;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    /// <summary>
    /// This method implementation will get a single order from the database.
    /// </summary>
    /// <param name="id">The primary key of the order to search.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Order"/>.</returns>
    public async Task<Order?> GetOrderAsync(int id)
    {
        var dbResult = await this.context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        return dbResult;
    }

    /// <summary>
    /// This method implementation will get all of the orders from the database.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="Order"/>.</returns>
    public async Task<List<Order>> GetOrdersAsync()
    {
        IQueryable<Order> query = this.context.Orders.AsNoTracking();

        return await query
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    /// <summary>
    /// This method implementation will update an existing order.
    /// </summary>
    /// <param name="order">The relevant order information to update.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Order"/>.</returns>
    public async Task<Order?> UpdateOrderAsync(Order order)
    {
        this.context.ChangeTracker.Clear();
        this.context.Orders.Update(order);
        var result = await this.context.SaveChangesAsync();
        return result > 0 ? order : null!;
    }
}
