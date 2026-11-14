// <copyright file="IOrderService.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.Services.Interfaces;

using NorthwindPizza.Api.DTO.Models;
using NorthwindPizza.Api.DTO.Request;

/// <summary>
/// This interface contains methods that interact with the Order DTO entity.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// This method definition will create the relevant order.
    /// </summary>
    /// <param name="request">The relevant request for creating an order.</param>
    /// <returns>A unit of execution that contains a type of <see cref="Order"/>.</returns>
    Task<Order?> CreateOrderAsync(CreateOrderRequest request);
}
