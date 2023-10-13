using Mamma.Mia.Pizzeria.DataAccess.DbContext;
using Mamma.Mia.Pizzeria.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.DataAccess.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MammaMiaPizzeriaDbContext _database;

        public BaseRepository(MammaMiaPizzeriaDbContext mammaMiaPizzeriaDbContext)
        {
            _database = mammaMiaPizzeriaDbContext;
        }

        public async Task Add(T entity)
        {
            try
            {
                _database.Set<T>().Add(entity);
                await _database.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                List<T> getall = await _database.Set<T>().ToListAsync();
                return getall;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetById(string id)
        {
            try
            {
                return _database.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetByIdInt(int id)
        {
            try
            {
                return _database.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Remove(T entity)
        {
            try
            {
                _database.Remove(entity);
                await _database.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveChanges()
        {
            try
            {
                await _database.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                _database.Set<T>().Update(entity);
                await _database.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
