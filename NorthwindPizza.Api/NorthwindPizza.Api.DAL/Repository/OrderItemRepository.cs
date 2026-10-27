using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

namespace NorthwindPizza.Api.DAL.Repository;

/// <summary>
/// This class implements the methods defined in <see cref="IOrderItemRepository"/>.
/// </summary>
/// <remarks>
/// TODO: Define and implement a method to get all of the order items based on an order ID
/// TODO: Define and implement a method to insert the relevant order items for a particular order
/// </remarks>
public class OrderItemRepository(NorthwindPizzaContext context) : IOrderItemRepository
{
    private readonly NorthwindPizzaContext context = context;

    public async Task<List<OrderItem>> GetOrderItemsAsync(int orderId)
    {
        var dbResults = await this.context.OrderItems.Where(g => g.OrderId == orderId).ToListAsync();
        return dbResults!;
    }
}
