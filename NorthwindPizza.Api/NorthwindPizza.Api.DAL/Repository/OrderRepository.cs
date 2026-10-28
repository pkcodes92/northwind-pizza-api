using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

namespace NorthwindPizza.Api.DAL.Repository;

public class OrderRepository(NorthwindPizzaContext context) : IOrderRepository
{
    private readonly NorthwindPizzaContext context = context;

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

    public async Task<Order?> GetOrderAsync(int id)
    {
        var dbResult = await this.context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        return dbResult;
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        IQueryable<Order> query = this.context.Orders.AsNoTracking();

        return await query
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }
}
