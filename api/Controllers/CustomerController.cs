using System;
using System.Collections.Generic;
using api.handlers;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private CustomerHandler _custHandler = new CustomerHandler();

        [HttpGet]
        [Route("/customers")]
        public IEnumerable<Customer> Get()
        {
            return _custHandler.GetAllCustomers();
        }

    }
}
