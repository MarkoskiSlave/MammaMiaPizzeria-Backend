using AutoMapper;
using Mamma.Mia.Pizzeria.Domain.Models;
using Mamma.Mia.Pizzeria.Dtos.OrderDtos;
using Mamma.Mia.Pizzeria.Dtos.PizzaDtos;
using Mamma.Mia.Pizzeria.Dtos.UserDtos;

namespace Mamma.Mia.Pizzeria.Mappers.MappersConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //userMapping
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            //PizzaMappings
            CreateMap<Pizza, PizzaDto>().ReverseMap();
            CreateMap<Pizza, AddPizzaDto>().ReverseMap();
            CreateMap<Pizza, UpdatePizzaDto>().ReverseMap();

            //OrderMapping
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, AddOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
        }
    }
}
