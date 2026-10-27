using NorthwindPizza.Api.DAL.Models;

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

public interface IOrderItemRepository
{
    Task<List<OrderItem>> GetOrderItemsAsync(int orderId);
}
