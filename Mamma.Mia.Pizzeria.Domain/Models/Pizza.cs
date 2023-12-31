﻿using Mamma.Mia.Pizzeria.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Domain.Models
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Price { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        public List<IngridientsEnum> Ingridients { get; set; } = new List<IngridientsEnum>();
        public int? OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
    }
}
