using NorthwindPizza.Api.DAL.Models;

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersAsync();

    Task<Order> CreateOrderAsync(Order order, List<OrderItem> orderItems);

    Task<Order?> GetOrderAsync(int id);

    Task<Order?> UpdateOrderAsync(Order order);
}