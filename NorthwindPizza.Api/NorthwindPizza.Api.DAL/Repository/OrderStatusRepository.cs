// <copyright file="OrderStatusRepository.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Repository;

using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

/// <summary>
/// This class contains methods that interact with the OrderStatus database entity.
/// </summary>
/// <remarks>
/// This class implements methods that are defined in <see cref="IOrderStatusRepository"/>.
/// </remarks>
/// <param name="pizzaContext">The relevant database context injection.</param>
public class OrderStatusRepository(NorthwindPizzaContext pizzaContext) : IOrderStatusRepository
{
    private readonly NorthwindPizzaContext context = pizzaContext;

    /// <summary>
    /// This method implementation will add a new order status to the database.
    /// </summary>
    /// <param name="orderStatus">The new order status to add.</param>
    /// <returns>A unit of execution that contains a type of <see cref="OrderStatus"/>.</returns>
    public async Task<OrderStatus> AddOrderStatusAsync(OrderStatus orderStatus)
    {
        this.context.OrderStatuses.Add(orderStatus);
        var result = await this.context.SaveChangesAsync();
        return result > 0 ? orderStatus : null!;
    }

    /// <summary>
    /// This method implementation will remove an order status from the database.
    /// </summary>
    /// <param name="id">The ID of the order status to remove.</param>
    /// <returns>A unit of execution that contains a boolean that represents successful deletion.</returns>
    public async Task<bool> DeleteOrderStatusAsync(int id)
    {
        this.context.ChangeTracker.Clear();
        var orderStatusToDelete = await this.context.OrderStatuses.FirstOrDefaultAsync(os => os.OrderStatusId == id);
        this.context.OrderStatuses.Remove(orderStatusToDelete!);
        var result = await this.context.SaveChangesAsync();
        return result > 0;
    }

    /// <summary>
    /// This method implementation will get a single order status.
    /// </summary>
    /// <param name="id">The primary key of the order status to search.</param>
    /// <returns>A unit of execution that contains a type of <see cref="OrderStatus"/>.</returns>
    public async Task<OrderStatus> GetOrderStatusAsync(int id)
    {
        var result = await this.context.OrderStatuses.FirstOrDefaultAsync(g => g.OrderStatusId == id);
        return result!;
    }

    /// <summary>
    /// This method implementation will get a single order status.
    /// </summary>
    /// <param name="name">The name of the order status to search.</param>
    /// <returns>A unit of execution that contains a type of <see cref="OrderStatus"/>.</returns>
    public async Task<OrderStatus> GetOrderStatusAsync(string name)
    {
        var result = await this.context.OrderStatuses.FirstOrDefaultAsync(g => g.Name == name);
        return result!;
    }

    /// <summary>
    /// This method implementation will get all of the active order statuses.
    /// </summary>
    /// <returns>A unit of execution that contains a list of type <see cref="OrderStatus"/>.</returns>
    public async Task<List<OrderStatus>> GetOrderStatusesAsync()
    {
        var results = await this.context.OrderStatuses.Where(os => os.IsActive == 1).ToListAsync();
        return results;
    }

    /// <summary>
    /// This method implementation will update an existing order status in the database.
    /// </summary>
    /// <param name="orderStatus">The updated order status information.</param>
    /// <returns>A unit of execution that contains a type of <see cref="OrderStatus"/>.</returns>
    public async Task<OrderStatus> UpdateOrderStatusAsync(OrderStatus orderStatus)
    {
        this.context.ChangeTracker.Clear();
        this.context.OrderStatuses.Update(orderStatus);
        var result = await this.context.SaveChangesAsync();
        return result > 0 ? orderStatus : null!;
    }
}
