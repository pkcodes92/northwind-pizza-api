using NorthwindPizza.Api.DAL.Models;

namespace NorthwindPizza.Api.DAL.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync(int? statusId = null);
    }
}





























