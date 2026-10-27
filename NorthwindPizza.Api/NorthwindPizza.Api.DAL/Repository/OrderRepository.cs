using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

namespace NorthwindPizza.Api.DAL.Repository;

public class OrderRepository(NorthwindPizzaContext context) : IOrderRepository
{
    private readonly NorthwindPizzaContext context = context;

    public async Task<List<Order>> GetOrdersAsync(int? statusId = null)
    {
        IQueryable<Order> query = this.context.Orders.AsNoTracking();

        if (statusId.HasValue)
        {
            query = query.Where(o => o.OrderStatusId == statusId.Value);
        }

        return await query
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }
}






















