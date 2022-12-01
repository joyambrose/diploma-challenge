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
    public class ProductController : ControllerBase
    {
        private ProductHandler _prodHandler = new ProductHandler();

        [HttpGet]
        [Route("/products")]
        public IEnumerable<Product> Get()
        {
            return _prodHandler.GetAllProducts();
        }
    }
}

