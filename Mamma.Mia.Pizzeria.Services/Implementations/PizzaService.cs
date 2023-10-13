using AutoMapper;
using Mamma.Mia.Pizzeria.DataAccess.DbContext;
using Mamma.Mia.Pizzeria.Domain.Models;
using Mamma.Mia.Pizzeria.Dtos.PizzaDtos;
using Mamma.Mia.Pizzeria.Services.Interfaces;
using Mamma.Mia.Pizzeria.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Services.Implementations
{
    public class PizzaService : IPizzaService
    {

        private readonly MammaMiaPizzeriaDbContext _dbContext;
        private readonly IMapper _mapper;

        public PizzaService(MammaMiaPizzeriaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Response<PizzaDto>> CreatePizza(string userId, AddPizzaDto pizzaDto)
        {
            var pizza = _mapper.Map<Pizza>(pizzaDto);
            pizza.UserId = pizzaDto.UserId;
            _dbContext.Pizza.Add(pizza);
            await _dbContext.SaveChangesAsync();
            var pizzaDtoResult = _mapper.Map<PizzaDto>(pizza);
            return new Response<PizzaDto>(pizzaDtoResult);
        }

        public async Task<Response> DeletePizza(string UserId, int pizzaId)
        {
            var pizza = await _dbContext.Pizza.FindAsync(pizzaId);
            if (pizza == null)
            {
                return new Response("Pizza not found");
            }
            if (pizza.UserId == UserId)
                return new Response("You do not have permission to delete this pizza");

            _dbContext.Pizza.Remove(pizza);
            await _dbContext.SaveChangesAsync();
            return new Response() { IsSuccessfull = true };
        }

        public async Task<Response<List<PizzaDto>>> GetAllPizzas()
        {
            var pizzas = await _dbContext.Pizza.ToListAsync();
            var pizzaDtos = _mapper.Map<List<PizzaDto>>(pizzas);
            return new Response<List<PizzaDto>>(pizzaDtos);
        }

        public async Task<Response<PizzaDto>> GetPizzaById(int id)
        {
            var pizza = await _dbContext.Pizza.FindAsync(id);
            if (pizza == null)
                return new Response<PizzaDto>("Pizza not found");
            var pizzaDto = _mapper.Map<PizzaDto>(pizza);
            return new Response<PizzaDto>(pizzaDto);
        }

        public async Task<Response<PizzaDto>> UpdatePizza(string userId, int pizzaId, UpdatePizzaDto updatePizzaDto)
        {
            var pizza = await _dbContext.Pizza.FindAsync(pizzaId);
            if (pizza == null)
                return new Response<PizzaDto>("Pizza not found");

            if (pizza.UserId != userId)
                return new Response<PizzaDto>("It is not your pizza to update!");

            _mapper.Map(updatePizzaDto, pizza);
            await _dbContext.SaveChangesAsync();
            var pizzaDtoResult = _mapper.Map<PizzaDto>(pizza);
            return new Response<PizzaDto>(pizzaDtoResult);

        }
    }
}
