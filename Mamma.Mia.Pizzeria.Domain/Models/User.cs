﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Domain.Models
{
    public class User : IdentityUser
    {
        public bool FirstLogin { get; set; }
    }
}