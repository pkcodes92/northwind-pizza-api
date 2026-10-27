using NorthwindPizza.Api.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindPizza.Api.DTO.Response;

public class GetPizzaResponse
{
    public Pizza Pizza { get; set; } = null!;
}
