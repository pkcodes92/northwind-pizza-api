using NorthwindPizza.Api.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindPizza.Api.DAL.Repository.Interfaces
{
    public interface IPizzaRepository
    {
        Task<List<Pizza>> GetAllPizzasAsync();

        Task<Pizza> GetPizzaAsync(int id);
    }
}
