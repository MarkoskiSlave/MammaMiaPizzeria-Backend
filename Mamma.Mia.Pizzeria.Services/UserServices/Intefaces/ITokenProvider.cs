using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Services.UserServices.Intefaces
{
    public interface ITokenProvider<T>
    {
        Task<T?> GetTokenAsync(string key);
        Task SetTokenAsync(string key, T value);
    }
}
