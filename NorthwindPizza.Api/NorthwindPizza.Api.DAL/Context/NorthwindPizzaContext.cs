// <copyright file="NorthwindPizzaContext.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Context;

using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This class represents the relevant database layer for the API.
/// </summary>
/// <param name="options">The relevant database context options.</param>
public partial class NorthwindPizzaContext(DbContextOptions<NorthwindPizzaContext> options) : DbContext(options)
{
    public virtual DbSet<AppSetting> AppSettings => Set<AppSetting>();

    public virtual DbSet<Customer> Customers => Set<Customer>();

    public virtual DbSet<Employee> Employees => Set<Employee>();

    public virtual DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public virtual DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();

    public virtual DbSet<Order> Orders => Set<Order>();

    public virtual DbSet<Pizza> Pizzas => Set<Pizza>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*
         * Customers
         */
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers");

            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.FirstName).IsRequired();

            entity.Property(e => e.LastName).IsRequired();

            entity.Property(e => e.Email).IsRequired();

            entity.Property(e => e.Phone).IsRequired(false);

            entity.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        /*
         * Pizzas
         */
        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.ToTable("Pizzas", table =>
            {
                table.HasCheckConstraint(
                    "CK_Pizzas_BasePrice",
                    "BasePrice >= 0");

                table.HasCheckConstraint(
                    "CK_Pizzas_IsActive",
                    "IsActive IN (0, 1)");
            });

            entity.HasKey(e => e.PizzaId);

            entity.Property(e => e.Name).IsRequired();

            entity.Property(e => e.Description).IsRequired(false);

            entity.Property(e => e.BasePrice).IsRequired();

            entity.Property(e => e.ImageUrl).IsRequired();

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(1);            
        });

        /*
         * OrderStatuses
         */
        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.ToTable("OrderStatuses", table =>
            {
                table.HasCheckConstraint(
                    "CK_OrderStatuses_IsActive",
                    "IsActive IN (0, 1)");
            });

            entity.HasKey(e => e.OrderStatusId);

            entity.Property(e => e.Name).IsRequired();

            entity.HasIndex(e => e.Name).IsUnique();

            entity.Property(e => e.Description).IsRequired(false);

            entity.Property(e => e.DisplayOrder).IsRequired().HasDefaultValue(0);

            entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(1);
        });

        /*
         * Orders
         */
        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Orders", table =>
            {
                table.HasCheckConstraint(
                    "CK_Orders_TotalAmount",
                    "TotalAmount >= 0");
            });

            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.CustomerId).IsRequired();

            entity.Property(e => e.OrderStatusId).IsRequired().HasDefaultValue(1);

            entity.Property(e => e.OrderDate).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.TotalAmount).IsRequired().HasDefaultValue(0);
        });

        /*
         * OrderItems
         */
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItems", table =>
            {
                table.HasCheckConstraint(
                    "CK_OrderItems_Quantity",
                    "Quantity > 0");

                table.HasCheckConstraint(
                    "CK_OrderItems_UnitPrice",
                    "UnitPrice >= 0");

                table.HasCheckConstraint(
                    "CK_OrderItems_LineTotal",
                    "LineTotal >= 0");
            });

            entity.HasKey(e => e.OrderItemId);

            entity.Property(e => e.OrderId).IsRequired();

            entity.Property(e => e.PizzaId).IsRequired();

            entity.Property(e => e.Quantity).IsRequired();

            entity.Property(e => e.UnitPrice).IsRequired();

            entity.Property(e => e.LineTotal).IsRequired();
        });

        /* 
         * Employees 
         */
        modelBuilder.Entity<Employee>(entity => 
        {
            entity.ToTable("Employees", table =>
            {
                table.HasCheckConstraint(
                    "CK_Employess_IsActive",
                    "IsActive IN (0, 1)");
            });

            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.FirstName).IsRequired();

            entity.Property(e => e.LastName).IsRequired();

            entity.Property(e => e.Email).IsRequired();

            entity.Property(e => e.Role).IsRequired().HasDefaultValue("Employee");

            entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(1);
        });

        /*
         * AppSettings
         */
        modelBuilder.Entity<AppSetting>(entity => 
        {
            entity.ToTable("AppSettings");

            entity.HasKey(e => e.SettingId);

            entity.Property(e => e.SettingKey).IsRequired();

            entity.Property(e => e.SettingValue).IsRequired(false);
        });
    }
}
