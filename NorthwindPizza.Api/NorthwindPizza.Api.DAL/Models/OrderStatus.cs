// <copyright file="OrderStatus.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This class represents the OrderStatus database entity.
/// </summary>
public partial class OrderStatus
{
    /// <summary>
    /// The primary key of the order status entity.
    /// </summary>
    public int OrderStatusId { get; set; }

    /// <summary>
    /// The name of the order status.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The relevant description of the order status.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The relevant display order.
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// A value that indicates if the order status is active.
    /// </summary>
    public int IsActive { get; set; }
}

/// <summary>
/// This class extends the type of <see cref="OrderStatus"/>.
/// </summary>
public static class OrderStatusExtensions
{
    /// <summary>
    /// This method will convert a database entity to a DTO model.
    /// </summary>
    /// <param name="value">The relevant OrderStatus database entity.</param>
    /// <returns>A type of <see cref="DTO.Models.OrderStatus"/>.</returns>
    public static DTO.Models.OrderStatus ToDto(this OrderStatus value)
    {
        return new DTO.Models.OrderStatus
        {
            Id = value.OrderStatusId,
            Name = value.Name,
            Description = value.Description,
            DisplayOrder = value.DisplayOrder,
            IsActive = value.IsActive == 1,
        };
    }
}
