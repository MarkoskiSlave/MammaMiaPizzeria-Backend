using Mamma.Mia.Pizzeria.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Services.UserServices.Intefaces
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> GenerateTokenAsync(User user);
    }
}
