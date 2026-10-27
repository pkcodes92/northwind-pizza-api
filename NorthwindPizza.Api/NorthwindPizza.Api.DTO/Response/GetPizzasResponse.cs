using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response
{
    public class GetPizzasResponse
    {
        public List<Pizza> Pizzas { get; set; } = null!;
    }
}
