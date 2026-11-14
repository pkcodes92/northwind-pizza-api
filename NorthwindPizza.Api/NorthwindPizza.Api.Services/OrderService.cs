// <copyright file="OrderService.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.Services;

using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Request;
using NorthwindPizza.Api.Services.Interfaces;

/// <summary>
/// This class will help with the relevant orders.
/// </summary>
/// <param name="orderRepo">The order repository injection.</param>
/// <param name="customerRepo">The customer repository injection.</param>
/// <param name="pizzaRepo">The pizza repository injection.</param>
/// <param name="orderStatusRepo">The order status repository injection.</param>
public class OrderService(
    IOrderRepository orderRepo,
    ICustomerRepository customerRepo,
    IPizzaRepository pizzaRepo,
    IOrderStatusRepository orderStatusRepo)
    : IOrderService
{
    private readonly IOrderRepository orderRepo = orderRepo;

    private readonly ICustomerRepository customerRepo = customerRepo;

    private readonly IPizzaRepository pizzaRepo = pizzaRepo;

    private readonly IOrderStatusRepository orderStatusRepo = orderStatusRepo;

    /// <summary>
    /// This method will create the relevant order entity.
    /// </summary>
    /// <param name="request">The relevant order request.</param>
    /// <returns>A unit of execution that contains a type of <see cref="DTO.Models.Order"/>.</returns>
    /// <exception cref="ArgumentException">This exception is thrown when the order request is invalid.</exception>
    /// <exception cref="KeyNotFoundException">
    /// This exception is thrown when the relevant pizza ID is not found.
    /// </exception>
    public async Task<DTO.Models.Order?> CreateOrderAsync(CreateOrderRequest request)
    {
        if (request.CustomerId <= 0 || request.Items is null ||
            request.Items.Count == 0 ||
            request.Items.Any(i => i.PizzaId <= 0 || i.Quantity <= 0) ||
            request.Items.GroupBy(i => i.PizzaId).Any(g => g.Count() > 1))
        {
            throw new ArgumentException("The order request is invalid.");
        }

        // Verify the customer exists.
        var customer = await this.customerRepo.GetCustomerAsync(request.CustomerId);

        if (customer is not null)
        {
            var orderItems = new List<OrderItem>();
            decimal totalAmount = 0;

            foreach (var requestedItem in request.Items)
            {
                var pizza = await this.pizzaRepo.GetPizzaAsync(requestedItem.PizzaId);

                if (pizza is not null)
                {
                    if (!pizza.ToDto().IsActive)
                    {
                        throw new ArgumentException($"Pizza {requestedItem.PizzaId} is inactive.");
                    }

                    var unitPrice = pizza.BasePrice;
                    var lineTotal = unitPrice * requestedItem.Quantity;

                    orderItems.Add(new OrderItem
                    {
                        PizzaId = pizza.PizzaId,
                        Quantity = requestedItem.Quantity,
                        UnitPrice = unitPrice,
                        LineTotal = lineTotal,
                    });

                    totalAmount += lineTotal;
                }
                else
                {
                    throw new KeyNotFoundException($"Pizza {requestedItem.PizzaId} not found.");
                }
            }

            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderStatusId = 1, // Assumes 1 = Pending
                TotalAmount = totalAmount,
                OrderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            };

            var dbOrder = await this.orderRepo.CreateOrderAsync(order, orderItems);

            var dboOrderStatus = await this.orderStatusRepo.GetOrderStatusAsync(dbOrder.OrderStatusId);

            var dbCustomer = await this.customerRepo.GetCustomerAsync(dbOrder.CustomerId);

            return dbOrder.ToDto(dboOrderStatus, dbCustomer!);
        }

        throw new KeyNotFoundException("Customer cannot found.");
    }
}
