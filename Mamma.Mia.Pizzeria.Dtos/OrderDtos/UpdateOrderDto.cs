﻿using Mamma.Mia.Pizzeria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string UserId { get; set; } = string.Empty;
        public string AdressTo { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int OrderPrice { get; set; }
        public List<Pizza>? Pizzas { get; set; } = new List<Pizza>();
    }
}