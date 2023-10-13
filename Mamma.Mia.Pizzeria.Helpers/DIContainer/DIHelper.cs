using Mamma.Mia.Pizzeria.DataAccess.DbContext;
using Mamma.Mia.Pizzeria.DataAccess.Repositories.Implementations;
using Mamma.Mia.Pizzeria.DataAccess.Repositories.Interfaces;
using Mamma.Mia.Pizzeria.Services.Implementations;
using Mamma.Mia.Pizzeria.Services.Interfaces;
using Mamma.Mia.Pizzeria.Services.UserServices.Implementations;
using Mamma.Mia.Pizzeria.Services.UserServices.Intefaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mamma.Mia.Pizzeria.Helpers.DIContainer
{
    public static class DIHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MammaMiaPizzeriaDbContext>(x => x.UseNpgsql(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
