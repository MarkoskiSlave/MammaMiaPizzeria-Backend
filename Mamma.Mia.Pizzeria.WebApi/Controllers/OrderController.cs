using Mamma.Mia.Pizzeria.Domain.Models;
using Mamma.Mia.Pizzeria.Dtos.OrderDtos;
using Mamma.Mia.Pizzeria.Services.Interfaces;
using Mamma.Mia.Pizzeria.Shared.CustomExceptions.OrderExceptions;
using Mamma.Mia.Pizzeria.Shared.CustomExceptions.ServerExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mamma.Mia.Pizzeria.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                var response = await _orderService.GetAllOrders();
                return Response(response);
            }
            catch (OrderDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var response = await _orderService.GetOrderById(id);
                return Response(response);
            }
            catch (OrderNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] AddOrderDto orderDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //var userId = orderDto.UserId;
                var response = await _orderService.CreateOrder(userId, orderDto);
                return Response(response);
            }
            catch (OrderDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDto updatedOrderDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var response = await _orderService.UpdateOrder(userId, id, updatedOrderDto);
                return Response(response);
            }
            catch (OrderDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var response = await _orderService.DeleteOrder(userId, id);
                return Response(response);
            }
            catch (OrderDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
