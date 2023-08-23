using MassTransit;
using MassTransit.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Microservice.Entity.Models;
using Orders.Microservice.OrderSupervisor;
using System.Collections.Generic;

namespace Orders.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private readonly IBus _busService;
        private readonly IOrderSupervisor _orderSupervisor;
        public OrderServiceController(IOrderSupervisor supervisor)
        {
            _orderSupervisor = supervisor;
        }

        [HttpPost("addOrder")]
        public async Task<Order> addOrderAsync(Order order)
        {
            var orderData = await _orderSupervisor.addOrder(order);
            if (orderData != null)
            {
                var isSent = _orderSupervisor.SendNotification(order);
                if (isSent)
                {
                    return order;
                }
                return null; ;
            }
            
            return null;
        }

        [HttpPost("getOrders")]
        public async Task<ActionResult<Order>> getOrders()
        {

            var result = await _orderSupervisor.getOrders();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
