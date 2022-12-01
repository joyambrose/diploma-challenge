using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.handlers;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private OrderHandler _orderHandler = new OrderHandler();

        [HttpGet]
        [Route("/orders")]
        public IEnumerable<Order> Get()
        {
            return _orderHandler.GetAllOrders();
        }

        [HttpPut]
        [Route("/create-order")]
        public int CreateOrder([FromBody]Order order) 
        {
            return _orderHandler.CreateOrder(order);
        }

        [HttpDelete]
        [Route("/delete-order")]
        public int DeleteOrder([FromBody]Order order)
        {
            return _orderHandler.DeleteOrder(order);
        }
    }
}
