using Mamma.Mia.Pizzeria.DataAccess.DbContext;
using Mamma.Mia.Pizzeria.DataAccess.Repositories.Interfaces;
using Mamma.Mia.Pizzeria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.DataAccess.Repositories.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly MammaMiaPizzeriaDbContext _database;

        public OrderRepository(MammaMiaPizzeriaDbContext database) :base(database)
        {
            _database = database;
        }
    }
}
