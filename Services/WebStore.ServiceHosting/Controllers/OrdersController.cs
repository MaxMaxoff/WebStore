using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.DTO.Order;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [ApiController, Route("api/[controller]"), Produces("application/json")]
    public class OrdersController : ControllerBase, IOrderService
    {
        private readonly IOrderService _IOrderService;

        public OrdersController(IOrderService OrderService) => _IOrderService = OrderService;

        [HttpGet("user/{UserName}")]
        public IEnumerable<OrderDTO> GetUserOrders(string UserName)
        {
            return _IOrderService.GetUserOrders(UserName);
        }

        [HttpGet("{id}"), ActionName("get")]
        public OrderDTO GetOrderById(int id)
        {
            return _IOrderService.GetOrderById(id);
        }

        [HttpPost("{UserName?}")]
        public OrderDTO CreateOrder([FromBody] CreateOrderModel Model, string UserName)
        {
            return _IOrderService.CreateOrder(Model, UserName);
        }
    }
}