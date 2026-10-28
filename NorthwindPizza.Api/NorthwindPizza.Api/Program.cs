using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Repository;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Response;
using NorthwindPizza.Api.Services;
using NorthwindPizza.Api.Services.Interfaces;
using Scalar.AspNetCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetValue<string>("ConnectionString");
builder.Services.AddDbContext<NorthwindPizzaContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IAppSettingRepository, AppSettingRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(opts => {
    opts.AddScalarTransformers();
    opts.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        var tagDescriptions = new Dictionary<string, string>
        {
            ["Pizzas"] = "The endpoint collection about the Pizza entity.",
            ["Order Status"] = "The endpoint collection about the Order Status entity.",
            ["Customers"] = "The endpoint collection about the Customer entity.",
            ["Employees"] = "The enpoint collection about the Employee entity.",
            ["Orders"] = "The endpoint collection about the Order entity."
        };

        foreach (var tag in tagDescriptions)
        {
            var existingTag = document.Tags?.FirstOrDefault(t => t.Name == tag.Key);

            if (existingTag is not null)
            {
                // The tag already exists, so update its description.
                existingTag.Description = tag.Value;
            }
            else
            {
                document!.Tags!.Add(new OpenApiTag
                {
                    Name = tag.Key,
                    Description = tag.Value
                });
            }
        }


        return Task.CompletedTask;
    });
});

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Title = "Northwind Pizza API";
    options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

app.UseHttpsRedirection();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();

        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

        if (exceptionHandler is not null)
        {
            logger.LogError(exceptionHandler.Error,
                "An unexpected error occurred while processing the request.");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Response.ContentType = "application/json";

            var response = new ErrorResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "An unexpected error occurred."
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    });
});

app.UseAuthorization();

app.MapControllers();

app.Run();
