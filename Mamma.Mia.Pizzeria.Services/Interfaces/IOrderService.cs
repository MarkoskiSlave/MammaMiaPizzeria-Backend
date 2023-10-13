using Mamma.Mia.Pizzeria.Dtos.OrderDtos;
using Mamma.Mia.Pizzeria.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Response<List<OrderDto>>> GetAllOrders();
        Task<Response<OrderDto>> GetOrderById(int id);
        Task<Response<OrderDto>> CreateOrder(string userId, AddOrderDto orderDto);
        Task<Response<OrderDto>> UpdateOrder(string userId, int orderId, UpdateOrderDto updatedOrderDto);
        Task<Response> DeleteOrder(string userId, int orderId);
    }
}
